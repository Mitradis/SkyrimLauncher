using System;
using System.Collections.Generic;
using System.IO;

namespace SkyrimLauncher
{
    public static class FuncClear
    {
        static List<string> ignoreImportList = new List<string>();
        static List<string> ingoredFoldersImportList = new List<string>();

        public static List<string> ignoreList()
        {
            return new List<string>() {
                "_programs",
                "atimgpud.dll",
                "binkw32.dll",
                "d3d9.dll",
                "d3d9.ini",
                "d3d9_fxaa.dll",
                "d3d9_smaa.dll",
                "data|additemmenu2.bsa",
                "data|additemmenu2.esp",
                "data|ahzmorehud.bsa",
                "data|ahzmorehud.esp",
                "data|alternatestart.bsa",
                "data|alternatestart.esp",
                "data|alwayspickupbooks.bsa",
                "data|alwayspickupbooks.esp",
                "data|armorweapon.bsa",
                "data|armorweapon.esp",
                "data|audiooverhaulskyrim.bsa",
                "data|audiooverhaulskyrim.esp",
                "data|bfseffects.bsa",
                "data|bfseffects.esp",
                "data|blacksmith chests.bsa",
                "data|blacksmith chests.esp",
                "data|book covers skyrim.bsa",
                "data|book covers skyrim.esp",
                "data|camerascripter.bsa",
                "data|camerascripter.esp",
                "data|camerascripts",
                "data|campfire.bsa",
                "data|campfire.esm",
                "data|coinpurse.bsa",
                "data|coinpurse.esp",
                "data|customfonts.bsa",
                "data|customizable camera.bsa",
                "data|customizable camera.esp",
                "data|cutting room floor.bsa",
                "data|cutting room floor.esp",
                "data|dawnguard.esm",
                "data|deadlyspellimpacts.bsa",
                "data|deadlyspellimpacts.esp",
                "data|destructiblebottles.bsa",
                "data|destructiblebottles.esp",
                "data|disablefasttravel.bsa",
                "data|disablefasttravel.esp",
                "data|dragonborn.esm",
                "data|dual sheath redux patch.esp",
                "data|dual sheath redux.bsa",
                "data|dual sheath redux.esp",
                "data|dual wield parrying.bsa",
                "data|dual wield parrying.esp",
                "data|enb vision.esp",
                "data|enhanced blood.bsa",
                "data|enhanced blood.esp",
                "data|enhancedlightsfx.bsa",
                "data|enhancedlightsfx.esp",
                "data|eyeshairs.bsa",
                "data|eyeshairs.esp",
                "data|florarespawnfix.bsa",
                "data|florarespawnfix.esp",
                "data|fnis.bsa",
                "data|fnis.esp",
                "data|fnis.ini",
                "data|follower commentary.bsa",
                "data|follower commentary.esp",
                "data|footprints.bsa",
                "data|footprints.esp",
                "data|frostfall.bsa",
                "data|frostfall.esp",
                "data|gamecomm.bsa",
                "data|gamemesh1.bsa",
                "data|gamemesh2.bsa",
                "data|gamemesh3.bsa",
                "data|gametext1.bsa",
                "data|gametext10.bsa",
                "data|gametext2.bsa",
                "data|gametext3.bsa",
                "data|gametext4.bsa",
                "data|gametext5.bsa",
                "data|gametext6.bsa",
                "data|gametext7.bsa",
                "data|gametext8.bsa",
                "data|gametext9.bsa",
                "data|gamevoice1.bsa",
                "data|gamevoice2.bsa",
                "data|getsnowy.bsa",
                "data|getsnowy.esp",
                "data|headtracking.bsa",
                "data|headtracking.esp",
                "data|hearthfires.esm",
                "data|helmettoggle.bsa",
                "data|helmettoggle.esp",
                "data|horsearmor.bsa",
                "data|horsearmor.esp",
                "data|ihud.bsa",
                "data|ihud.esp",
                "data|immersive citizens.bsa",
                "data|immersive citizens.esp",
                "data|ineed.bsa",
                "data|ineed.esp",
                "data|interiors furniture fix.bsa",
                "data|interiors furniture fix.esp",
                "data|jaxonzmapmarkers.bsa",
                "data|jaxonzmapmarkers.esp",
                "data|landscape improved.bsa",
                "data|landscape improved.esp",
                "data|leveled enemy.bsa",
                "data|leveled enemy.esp",
                "data|meshes|0sa",
                "data|meshes|0sp",
                "data|meshes|actors|character|animations|0sex_0mf_d",
                "data|meshes|actors|character|animations|0sex_0mf_k",
                "data|meshes|actors|character|animations|0sex_0mf_m",
                "data|meshes|actors|character|animations|0sex_0mf_s",
                "data|meshes|actors|character|animations|0sex_0mf_u",
                "data|meshes|actors|character|animations|0sex_emf_a",
                "data|meshes|actors|character|animations|_esg_0er_f",
                "data|meshes|actors|character|animations|_esg_0er_m",
                "data|meshes|actors|character|animations|fnisbase",
                "data|meshes|actors|character|behaviors",
                "data|meshes|actors|character|character assets female|skeleton_female.hkx",
                "data|meshes|actors|character|character assets|skeleton.hkx",
                "data|meshes|actors|character|characters female|defaultfemale.hkx",
                "data|meshes|actors|character|characters|defaultmale.hkx",
                "data|meshes|animationdatasinglefile.txt",
                "data|meshes|animationsetdatasinglefile.txt",
                "data|meshes|armor|chesko",
                "data|meshes|armor|naked",
                "data|meshes|armor|weaponsling",
                "data|meshes|clothes|cloaks",
                "data|meshes|clothes|hdt test earring",
                "data|meshes|clothes|horsecloak",
                "data|meshes|hair|clark",
                "data|meshes|hair|havok physx",
                "data|meshes|hair|hdt untitled hairs",
                "data|meshes|hair|ks hairdo's",
                "data|meshes|hair|skyrim hdt hair",
                "data|occlusion of the worlds.esp",
                "data|ordinator.bsa",
                "data|ordinator.esp",
                "data|osa.bsa",
                "data|osa.esm",
                "data|overlays.bsa",
                "data|overlays.esp",
                "data|quests markers.bsa",
                "data|quests markers.esp",
                "data|racemenu.bsa",
                "data|racemenu.esp",
                "data|removefakedirectlight.esp",
                "data|scripts|fnis_aa2.pex",
                "data|scripts|fnisversiongenerated.pex",
                "data|skse|plugins|additemmenu2.dll",
                "data|skse|plugins|additemmenu2.ini",
                "data|skse|plugins|ahzmorehudplugin.dll",
                "data|skse|plugins|animationloadingfix.dll",
                "data|skse|plugins|armor_rating_rescaled.dll",
                "data|skse|plugins|armor_rating_rescaled.ini",
                "data|skse|plugins|barterfix.dll",
                "data|skse|plugins|bugfixplugin.dll",
                "data|skse|plugins|bugfixplugin.ini",
                "data|skse|plugins|camerascripter.dll",
                "data|skse|plugins|campfiredata",
                "data|skse|plugins|chargen",
                "data|skse|plugins|chargen.dll",
                "data|skse|plugins|chargen.ini",
                "data|skse|plugins|cobbbugfixes.dll",
                "data|skse|plugins|cobbbugfixes.ini",
                "data|skse|plugins|cpconvert.dll",
                "data|skse|plugins|cpconvert.ini",
                "data|skse|plugins|crashfixplugin.dll",
                "data|skse|plugins|crashfixplugin.ini",
                "data|skse|plugins|enchantreloadfix.dll",
                "data|skse|plugins|encounter_zones_unlocked.dll",
                "data|skse|plugins|encounter_zones_unlocked.ini",
                "data|skse|plugins|equipenchantmentfix.dll",
                "data|skse|plugins|frostfalldata",
                "data|skse|plugins|hdtphysicsextensions.dll",
                "data|skse|plugins|hdtphysicsextensions.ini",
                "data|skse|plugins|hdtphysicsextensionscrashfix.dll",
                "data|skse|plugins|hdtphysicsextensionsdefaultbbp.xml",
                "data|skse|plugins|improvement_names.dll",
                "data|skse|plugins|improvement_names.ini",
                "data|skse|plugins|mfgconsole.dll",
                "data|skse|plugins|mfgconsole.ini",
                "data|skse|plugins|nioverride.dll",
                "data|skse|plugins|nioverride.ini",
                "data|skse|plugins|npc ai behavior fixes.dll",
                "data|skse|plugins|npc ai behavior fixes.ini",
                "data|skse|plugins|osa.dll",
                "data|skse|plugins|ru_fix.dll",
                "data|skse|plugins|skse_enhancedcamera.dll",
                "data|skse|plugins|skse_enhancedcamera.ini",
                "data|skse|plugins|skse_russian_helper.dll",
                "data|skse|plugins|skyrimsouls.dll",
                "data|skse|plugins|skyrimsouls.ini",
                "data|skse|plugins|smart souls.dll",
                "data|skse|plugins|smart souls.ini",
                "data|skse|plugins|storageutil.dll",
                "data|skse|plugins|unequipquiver.dll",
                "data|skse|plugins|unequipquiver.ini",
                "data|skse|plugins|wearablelanternsdata",
                "data|skse|plugins|which_quests_item.dll",
                "data|skse|plugins|which_quests_item.ini",
                "data|skse|skse.ini",
                "data|skyproc patchers|dual sheath redux patch|dual sheath redux patch.jar",
                "data|skyrim.esm",
                "data|skyui.bsa",
                "data|skyui.esp",
                "data|staticloadingscreens.bsa",
                "data|staticloadingscreens.esp",
                "data|tools|generatefnis_for_users|alternate_animationgroups.txt",
                "data|tools|generatefnis_for_users|animevents.txt",
                "data|tools|generatefnis_for_users|animvars.txt",
                "data|tools|generatefnis_for_users|customprecachefiles.txt",
                "data|tools|generatefnis_for_users|debugdata.txt",
                "data|tools|generatefnis_for_users|dontaskagainforlink.txt",
                "data|tools|generatefnis_for_users|fnis_templates.txt",
                "data|tools|generatefnis_for_users|fnismodlist.txt",
                "data|tools|generatefnis_for_users|generatefnisforusers.exe",
                "data|tools|generatefnis_for_users|hkxcmd.exe",
                "data|tools|generatefnis_for_users|languages",
                "data|tools|generatefnis_for_users|mypatches.txt",
                "data|tools|generatefnis_for_users|patchanimationfiles.txt",
                "data|tools|generatefnis_for_users|patchlist.txt",
                "data|tools|generatefnis_for_users|templates",
                "data|tools|generatefnis_for_users|temporary_logs|.temporary_logs.txt",
                "data|uiextensions.bsa",
                "data|uiextensions.esp",
                "data|unofficial skyrim legendary edition patch.bsa",
                "data|unofficial skyrim legendary edition patch.esp",
                "data|update.bsa",
                "data|update.esm",
                "data|wearable lantern.bsa",
                "data|wearable lantern.esp",
                "data|weather svwi.esp",
                "data|wondersofweather.bsa",
                "data|wondersofweather.esp",
                "enbhost.exe",
                "enbinjector.exe",
                "enbinjector.ini",
                "enblocal.ini",
                "enbseries",
                "enbseries.dll",
                "enbseries.ini",
                "fxaa_tool.exe",
                "injfx_shaders",
                "shader.fx",
                "skse_1_9_32.dll",
                "skse_loader.dll",
                "skyrim.exe",
                "skyrimlauncher.exe",
                "skyrim|7z.dll",
                "skyrim|7z.exe",
                "skyrim|customctrl.txt",
                "skyrim|enb",
                "skyrim|launcher.ini",
                "skyrim|mods",
                "skyrim|plugins.txt",
                "skyrim|skyrim.ini",
                "skyrim|skyrimprefs.ini",
                "skyrim|system",
                "smaa.fx",
                "smaa.h",
                "steam_api.dll",
                "tesv.exe" };
        }
        static List<string> ingoredFoldersList()
        {
            return new List<string>() {
                "_programs",
                "data|camerascripts",
                "data|meshes|0sa",
                "data|meshes|0sp",
                "data|meshes|actors|character|animations|0sex_0mf_d",
                "data|meshes|actors|character|animations|0sex_0mf_k",
                "data|meshes|actors|character|animations|0sex_0mf_m",
                "data|meshes|actors|character|animations|0sex_0mf_s",
                "data|meshes|actors|character|animations|0sex_0mf_u",
                "data|meshes|actors|character|animations|0sex_emf_a",
                "data|meshes|actors|character|animations|_esg_0er_f",
                "data|meshes|actors|character|animations|_esg_0er_m",
                "data|meshes|actors|character|animations|fnisbase",
                "data|meshes|actors|character|behaviors",
                "data|meshes|armor|chesko",
                "data|meshes|armor|naked",
                "data|meshes|armor|weaponsling",
                "data|meshes|clothes|cloaks",
                "data|meshes|clothes|hdt test earring",
                "data|meshes|clothes|horsecloak",
                "data|meshes|hair|clark",
                "data|meshes|hair|havok physx",
                "data|meshes|hair|hdt untitled hairs",
                "data|meshes|hair|hhairstyles",
                "data|meshes|hair|ks hairdo's",
                "data|meshes|hair|skyrim hdt hair",
                "data|skse|plugins|campfiredata",
                "data|skse|plugins|chargen",
                "data|skse|plugins|frostfalldata",
                "data|skse|plugins|wearablelanternsdata",
                "data|tools|generatefnis_for_users|languages",
                "data|tools|generatefnis_for_users|templates",
                "enbseries",
                "injfx_shaders",
                "skyrim|enb",
                "skyrim|mods",
                "skyrim|system" };
        }
        public static void clearGameFolder()
        {
            ignoreImportList = ignoreList();
            string line = FuncParser.stringRead(FormMain.pathLauncherINI, "Clearing", "IgnoreList");
            if (!String.IsNullOrEmpty(line))
            {
                ignoreImportList.AddRange(line.Split(new string[] { "¦" }, StringSplitOptions.None));
            }
            ingoredFoldersImportList = ingoredFoldersList();
            line = FuncParser.stringRead(FormMain.pathLauncherINI, "Clearing", "FoldersIgnored");
            if (!String.IsNullOrEmpty(line))
            {
                ingoredFoldersImportList.AddRange(line.Split(new string[] { "¦" }, StringSplitOptions.None));
            }
            changeSeparator(ignoreImportList, FormMain.pathSeparator);
            changeSeparator(ingoredFoldersImportList, FormMain.pathSeparator);
            clearFolder(FormMain.pathGameFolder);
            ingoredFoldersImportList.Clear();
            ignoreImportList.Clear();
        }
        private static void changeSeparator(List<string> list, string line)
        {
            int count = list.Count;
            for (int i = 0; i < count; i++)
            {
                list[i] = list[i].Replace("|", line);
            }
        }
        private static void clearFolder(string path)
        {
            if (Directory.Exists(path))
            {
                foreach (string line in Directory.EnumerateFiles(path))
                {
                    if (!ignoreImportList.Exists(s => s.StartsWith(line.Remove(0, FormMain.gameDirLength), StringComparison.OrdinalIgnoreCase)))
                    {
                        FuncFiles.deleteAny(line);
                    }
                }
                foreach (string line in Directory.EnumerateDirectories(path))
                {
                    string dirName = line.Remove(0, FormMain.gameDirLength);
                    if (!ignoreImportList.Exists(s => s.StartsWith(dirName, StringComparison.OrdinalIgnoreCase)))
                    {
                        FuncFiles.deleteAny(line);
                    }
                    else if (!ingoredFoldersImportList.Exists(s => s.Equals(dirName, StringComparison.OrdinalIgnoreCase)))
                    {
                        clearFolder(line);
                    }
                }
                if (Directory.GetFiles(path).Length == 0 && Directory.GetDirectories(path).Length == 0)
                {
                    FuncFiles.deleteAny(path);
                }
            }
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        public static void removeENB(bool proxy)
        {
            foreach (string line in proxy ? new string[] { "injfx_shaders", "d3d.log", "d3d9.ini", "d3d9_fxaa.dll", "d3d9_smaa.dll", "fxaa_tool.exe", "shader.fx", "smaa.fx", "smaa.h" } : new string[] { "enbseries", "d3d9.dll", "enbhost.exe", "enbinjector.exe", "enbinjector.ini", "enblocal.ini", "enbseries.dll", "enbseries.ini", "injfx_shaders", "d3d.log", "d3d9.ini", "d3d9_fxaa.dll", "d3d9_smaa.dll", "fxaa_tool.exe", "shader.fx", "smaa.fx", "smaa.h" })
            {
                FuncFiles.deleteAny(FormMain.pathGameFolder + line);
            }
            FuncFiles.deleteAny(FormMain.pathDataFolder + "enb vision.esp");
        }
    }
}