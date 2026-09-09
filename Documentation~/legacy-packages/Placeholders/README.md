# Virtuademy-CreatorKit-Worlds-Placeholders

## Why there is no `[MovedFrom]` on the runtime types

The brand rename briefly put
`[MovedFrom(false, "Reflectis.CreatorKit.Worlds.Placeholders", "Reflectis.CreatorKit.Worlds.Placeholders")]`
on all 78 top-level runtime types, to record where they lived before. It was removed on
2026-09-07 because nothing it could have protected turned out to need it. The reasoning is
kept here so nobody spends the effort a second time.

**It does not help AssetBundles.** Measured on 2026-09-01: with the attribute compiled into
the assembly and the editor recompiled, a world built before the rename still lost every
placeholder. A bundle records its components by assembly name in its own type information
and Unity resolves that against the loaded assemblies directly, without consulting the
attribute. Worlds published before the rename have to be rebuilt — see
`docs/brand-rename-cutover.md` in the meta-repo. This was the case the attributes were added
for, and it is the case they fail.

**Scenes and prefabs never needed it.** A `MonoBehaviour` reference serialises as
`m_Script: {fileID: 11500000, guid: <script guid>, type: 3}` — a GUID and nothing else. The
type's namespace and class name do not appear, so renaming them is invisible to every scene
and prefab, in this project and in a creator's. The packages were renamed **in place**, so
every `.cs` kept its `.meta` GUID and those references never moved. An earlier version of
this file claimed the attribute kept a creator project openable before the rename migrator
ran; that claim was asserted rather than measured, and the serialised form above is why it
does not hold.

**Nothing here is a `[SerializeReference]` target either**, which is the case where Unity
does consult the attribute — a field of that kind stores assembly, namespace and class by
name. The only `[SerializeReference]` in the first-party packages is in
`Virtuademy-SDK-Graphs`, over its own node types, and none of those live here.

**Visual Scripting graphs are migrated, not attributed.** A graph asset stores the concrete
unit type by fully qualified name, so a namespace rename does break it — but Visual
Scripting resolves those names through its own type map, not through Unity's attribute. That
is what `VirtuademyRenameMigrator` in `Virtuademy-CreatorKit-Worlds-Core` is for.

One practical note, since it cost a build: the attribute lives in
`UnityEngine.Scripting.APIUpdating`, and when the rename added the `using` it landed in
whatever using block was nearest. In three of the seventy-two files that block was an
`#if UNITY_EDITOR` one, which compiles in the editor and fails a player build — a shape the
Env-Test harness cannot catch, because it compiles in the editor where `UNITY_EDITOR` is
defined. If a runtime type ever needs an editor-guarded namespace again, that is the trap.
