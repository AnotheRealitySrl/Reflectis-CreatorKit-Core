# Virtuademy.Environments.ScriptingApi

The surface an **interpreted script** in an authored world is allowed to call. One assembly, no
references of its own, and the only first-party assembly a script may name.

## Why it exists

Interpreted scripts (HybridCLR hot-update DLLs) are verified server-side against a whitelist —
`policy.json` in `SPACS-Virtuademy/DllVerification`, enforced by `DllVerificationEngine` with a
static Mono.Cecil scan before anything runs. That whitelist has always **allowed the assembly name
`Virtuademy.Environments.ScriptingApi` and the matching namespace prefix**, and **denied**
`Virtuademy.SDK`, `Virtuademy.CreatorKit`, `Virtuademy.Worlds`, `Virtuademy.Core` and
`Virtuademy.ClientModels` outright.

Until now that allowance pointed at nothing: no such assembly existed. The perimeter was therefore
maximal by accident — a script could reach `mscorlib`, a slice of `UnityEngine`, TextMeshPro and
nothing of ours — and the API the whitelist promised was unwritten. This is that API.

## The rule for adding to it

**Nothing here may introduce a capability the platform does not already grant through a shipped
Visual Scripting node.** A graph and a script get the same reach; each member's doc comment names
the node it corresponds to. That keeps the security question about the *mechanism* rather than
about a growing list of powers, and it means widening the surface starts with "which node is this?"

Adding a member is the only way to widen what scripts can do, so it is a deliberate act. Removing
one breaks published worlds, so treat the surface as public API from the first published script.

## What the whitelist forces on the API's shape

Three constraints, all discovered from the policy rather than chosen:

- **No `Task`, no `async`/`await`.** `System.Threading` is a denied prefix, so a script cannot even
  name `Task`. Anything asynchronous takes a callback (`System.Action`, which is allowed) or is
  driven by a coroutine — `IEnumerator` is `System.Collections`, allowed, and
  `StartCoroutine(IEnumerator)` is permitted while the string overload is not.
- **No first-party type in a signature, however indirect.** Only primitives, types this namespace
  declares, and `UnityEngine` types. A `UnityEvent` cannot cross it either, which is why
  `ILocalizationApi.LanguageChanged` is an `event Action<string>` with the UnityEvent subscription
  kept on the implementation side.
- **No generics on the surface.** A generic instantiated only from interpreted code has no AOT
  counterpart and fails at load, not at compile time.

## Shape

`World` is the entry point, with one property per capability group:

| Group | What it covers |
|---|---|
| `World.Player` | the local player's transforms, teleport, movement, avatar visibility, camera mode |
| `World.Localization` | current language, translation by key, language switching, the change event |
| `World.Session` | read-only session facts: id, multiplayer, master client, player count, shared clock |

`World.IsAvailable` says whether the runtime is present; the group properties throw
`InvalidOperationException` with an explanatory message when it is not, rather than returning null.

The implementation lives **outside this package entirely**, in the app:
`Assets/_Project/ScriptingApi/`, assembly `Virtuademy.Worlds.ScriptingApiBackend`. It installs
itself before the first scene loads. `World.Install` and `IWorldBackend` are `internal` with
`InternalsVisibleTo` for that one assembly: a script references this assembly in full, so a public
installer would let one script replace the surface every other script is calling.

**Why the app and not this package.** §1 of the package plan assigns `Assets/_Project` "`SM` · the
world systems · the implementations of the Environments game contracts", and what a creator installs
is `SPACS-*` + `Interface` + `Environments` — *not* SDK-Core. An implementation backed by `SM` and
by the SDK-Core system interfaces therefore cannot ship to creators, and putting it in this package
would have shipped it. The creator gets the surface; the platform provides what answers it. The
backend's own namespace, `Virtuademy.Worlds.*`, is on the whitelist's denied list, so a script cannot
reach around the facade to it.

Each call resolves the system it needs at the moment it is made, exactly as the equivalent node
does. Calling before the platform has booted therefore fails the same way a graph would — no
caching, no special grace.

## Known gaps

- **This package is not yet distributable, and the facade does not change that.** The Kit's own
  runtime assembly names `SM` in 56 files and takes eight `I*System` interfaces from
  `Virtuademy.SDK.Core` — a package §1 does not give creators. Those interfaces are exactly the
  "world/game contracts (hands, network room, players in scene, ownership, teleport, camera, spawn,
  sync vars, scene changes, placeholder events, tasks)" §1 assigns to *this* package, so they have to
  move here and their implementations stay in the app. Until that split happens, the facade is clean
  but the package around it still reaches for the framework.
- **Three groups, not the whole node vocabulary.** The shipped nodes cover 149 units in five
  categories: flow, events, get, expose, create. This is the first slice — player, localization,
  session facts. Dialogs, tasks, quiz, synced objects and variables, ownership, save data,
  analytics, spawning, contextual menu, control manager and the interactable events all still have
  no scripted equivalent.
- **No negative test.** `DllVerification/README.md` asks for red-team cases against the engine, and
  the package plan asks the test-env project to publish a script that deliberately reaches for
  `SM`, `AuthenticationSystem` and `System.IO` and to pass only when the publish is **rejected**.
  Neither exists yet, so the claim "a script cannot reach anything else" is currently supported by
  reading `policy.json`, not by a test.
- **`policy.json` allows the bare assembly name `HotUpdate`**, while `HotUpdateDllLocator`
  documents that Unity compiles the hot-update assembly as `HotUpdate_<productGUID>`. Whether that
  entry is dead depends on whether the engine matches an assembly's own name or only its
  references — unread so far.
- **The name is not frozen yet, and two documents disagree.** This assembly takes the name
  `policy.json` already ships, because that file is deployed and the plan's `§4`
  (`Virtuademy.HotUpdate.ScriptingApi`) is not. From the first published scripted world the name
  becomes a wire symbol and cannot change: a built bundle records components by assembly.
