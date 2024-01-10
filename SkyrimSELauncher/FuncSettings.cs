using System;
using System.Collections.Generic;
using System.IO;

namespace SkyrimSELauncher
{
    public class FuncSettings
    {
        public static void setSettingsPreset(int value)
        {
            if (value == 0)
            {
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "bFXAAEnabled", "1");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "bUseTAA", "0");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "fLightLODStartFade", "500.0000");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "LOD", "fLODFadeOutMultActors", "5.0000");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "LOD", "fLODFadeOutMultObjects", "5.0000");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "LOD", "fLODFadeOutMultItems", "3.0000");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "iShadowMapResolution", "512");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Grass", "fGrassStartFadeDistance", "2000.0000");
                FuncParser.iniWrite(FormMain.pathSkyrimINI, "Grass", "iMinGrassSize", "30");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "iNumFocusShadow", "1");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "fMeshLODLevel1FadeDist", "4096.0000");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "fMeshLODLevel2FadeDist", "3072.0000");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "fShadowDistance", "3000.0000");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "TerrainManager", "fTreeLoadDistance", "12500.0000");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "TerrainManager", "fBlockMaximumDistance", "100000.0000");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "TerrainManager", "fBlockLevel0Distance", "15000.0000");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "TerrainManager", "fBlockLevel1Distance", "25000.0000");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "TerrainManager", "fSplitDistanceMult", "0.5000");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "fTreesMidLODSwitchDist", "3500.0000");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "General", "uLargeRefLODGridSize", "5");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Decals", "bDecals", "0");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Decals", "bSkinnedDecals", "0");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Decals", "uMaxDecals", "0");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Decals", "uMaxSkinDecals", "0");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Decals", "iMaxDecalsPerFrame", "0");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Decals", "iMaxSkinDecalsPerFrame", "0");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "bVolumetricLightingEnable", "0");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "iVolumetricLightingQuality", "0");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "bScreenSpaceReflectionEnabled", "0");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "bSAOEnable", "1");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "bUsePrecipitationOcclusion", "0");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "bEnableProjecteUVDiffuseNormals", "0");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "bToggleSparkles", "0");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "bIBLFEnable", "0");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Imagespace", "bLensFlare", "0");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "bUse64bitsHDRRenderTarget", "0");
            }
            else if (value == 1)
            {
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "bFXAAEnabled", "0");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "bUseTAA", "1");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "fLightLODStartFade", "1000.0000");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "LOD", "fLODFadeOutMultActors", "7.0000");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "LOD", "fLODFadeOutMultObjects", "7.0000");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "LOD", "fLODFadeOutMultItems", "5.0000");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "iShadowMapResolution", "1024");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Grass", "fGrassStartFadeDistance", "4000.0000");
                FuncParser.iniWrite(FormMain.pathSkyrimINI, "Grass", "iMinGrassSize", "25");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "iNumFocusShadow", "2");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "fMeshLODLevel1FadeDist", "4096.0000");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "fMeshLODLevel2FadeDist", "3072.0000");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "fShadowDistance", "5000.0000");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "TerrainManager", "fTreeLoadDistance", "75000.0000");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "TerrainManager", "fBlockMaximumDistance", "100000.0000");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "TerrainManager", "fBlockLevel0Distance", "20000.0000");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "TerrainManager", "fBlockLevel1Distance", "32000.0000");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "TerrainManager", "fSplitDistanceMult", "1.1000");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "fTreesMidLODSwitchDist", "4000.0000");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "General", "uLargeRefLODGridSize", "7");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Decals", "bDecals", "1");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Decals", "bSkinnedDecals", "1");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Decals", "uMaxDecals", "100");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Decals", "uMaxSkinDecals", "35");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Decals", "iMaxDecalsPerFrame", "10");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Decals", "iMaxSkinDecalsPerFrame", "3");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "bVolumetricLightingEnable", "1");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "iVolumetricLightingQuality", "1");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "bScreenSpaceReflectionEnabled", "1");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "bSAOEnable", "1");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "bUsePrecipitationOcclusion", "1");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "bEnableProjecteUVDiffuseNormals", "1");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "bToggleSparkles", "1");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "bIBLFEnable", "1");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Imagespace", "bLensFlare", "1");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "bUse64bitsHDRRenderTarget", "0");
            }
            else if (value == 2)
            {
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "bFXAAEnabled", "0");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "bUseTAA", "1");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "fLightLODStartFade", "2500.0000");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "LOD", "fLODFadeOutMultActors", "9.0000");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "LOD", "fLODFadeOutMultObjects", "9.0000");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "LOD", "fLODFadeOutMultItems", "7.0000");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "iShadowMapResolution", "2048");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Grass", "fGrassStartFadeDistance", "5000.0000");
                FuncParser.iniWrite(FormMain.pathSkyrimINI, "Grass", "iMinGrassSize", "20");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "iNumFocusShadow", "4");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "fMeshLODLevel1FadeDist", "16896.0000");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "fMeshLODLevel2FadeDist", "16896.0000");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "fShadowDistance", "8000.0000");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "TerrainManager", "fTreeLoadDistance", "75000.0000");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "TerrainManager", "fBlockMaximumDistance", "250000.0000");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "TerrainManager", "fBlockLevel0Distance", "35000.0000");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "TerrainManager", "fBlockLevel1Distance", "70000.0000");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "TerrainManager", "fSplitDistanceMult", "1.5000");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "fTreesMidLODSwitchDist", "5000.0000");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "General", "uLargeRefLODGridSize", "9");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Decals", "bDecals", "1");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Decals", "bSkinnedDecals", "1");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Decals", "uMaxDecals", "1000");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Decals", "uMaxSkinDecals", "100");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Decals", "iMaxDecalsPerFrame", "100");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Decals", "iMaxSkinDecalsPerFrame", "25");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "bVolumetricLightingEnable", "1");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "iVolumetricLightingQuality", "1");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "bScreenSpaceReflectionEnabled", "1");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "bSAOEnable", "1");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "bUsePrecipitationOcclusion", "1");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "bEnableProjecteUVDiffuseNormals", "1");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "bToggleSparkles", "1");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "bIBLFEnable", "1");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Imagespace", "bLensFlare", "1");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "bUse64bitsHDRRenderTarget", "0");
            }
            else if (value == 3)
            {
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "bFXAAEnabled", "0");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "bUseTAA", "1");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "fLightLODStartFade", "3500.0000");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "LOD", "fLODFadeOutMultActors", "15.0000");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "LOD", "fLODFadeOutMultObjects", "15.0000");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "LOD", "fLODFadeOutMultItems", "10.0000");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "iShadowMapResolution", "4096");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Grass", "fGrassStartFadeDistance", "7000.0000");
                FuncParser.iniWrite(FormMain.pathSkyrimINI, "Grass", "iMinGrassSize", "15");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "iNumFocusShadow", "4");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "fMeshLODLevel1FadeDist", "16896.0000");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "fMeshLODLevel2FadeDist", "16896.0000");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "fShadowDistance", "10000.0000");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "TerrainManager", "fTreeLoadDistance", "75000.0000");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "TerrainManager", "fBlockMaximumDistance", "250000.0000");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "TerrainManager", "fBlockLevel0Distance", "60000.0000");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "TerrainManager", "fBlockLevel1Distance", "90000.0000");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "TerrainManager", "fSplitDistanceMult", "1.5000");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "fTreesMidLODSwitchDist", "16896.0000");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "General", "uLargeRefLODGridSize", "11");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Decals", "bDecals", "1");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Decals", "bSkinnedDecals", "1");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Decals", "uMaxDecals", "1000");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Decals", "uMaxSkinDecals", "100");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Decals", "iMaxDecalsPerFrame", "100");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Decals", "iMaxSkinDecalsPerFrame", "25");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "bVolumetricLightingEnable", "1");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "iVolumetricLightingQuality", "2");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "bScreenSpaceReflectionEnabled", "1");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "bSAOEnable", "1");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "bUsePrecipitationOcclusion", "1");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "bEnableProjecteUVDiffuseNormals", "1");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "bToggleSparkles", "1");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "bIBLFEnable", "1");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Imagespace", "bLensFlare", "1");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "bUse64bitsHDRRenderTarget", "1");
            }
            FormMain.settingsPreset = value;
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        public static List<string> skyrimINI()
        {
            return new List<string>
            {
                "[General]",
                "sLanguage=RUSSIAN",
                "sTestFile1=Dawnguard.esm",
                "sTestFile2=HearthFires.esm",
                "sTestFile3=Dragonborn.esm",
                "uGridsToLoad=5",
                "uExterior Cell Buffer=36",
                "uInterior Cell Buffer=4",
                "SIntroSequence=",
                "",
                "[Display]",
                "fShadowLODMaxStartFade=1000.0",
                "fSpecularLODMaxStartFade=2000.0",
                "fLightLODMaxStartFade=3500.0",
                "fLightLODStartFade=3500.0",
                "iShadowMapResolutionPrimary=2048",
                "bAllowScreenshot=1",
                "fTreesMidLODSwitchDist=9999999.0000",
                "fFirstSliceDistance=2000.0000",
                "fDynamicDOFFarBlur=0.4",
                "fDDOFFocusCenterweightExt=2",
                "fDOFMaxDepthParticipation=10000",
                "",
                "[Audio]",
                "fMusicDuckingSeconds=6.0",
                "fMusicUnDuckingSeconds=8.0",
                "fMenuModeFadeOutTime=3.0",
                "fMenuModeFadeInTime=1.0",
                "",
                "[SaveGame]",
                "iAutoSaveCount=6",
                "",
                "[Interface]",
                "bShowTutorials=0",
                "",
                "[Grass]",
                "bAllowCreateGrass=1",
                "bAllowLoadGrass=0",
                "fGrassMaxStartFadeDistance=7000.0000",
                "fGrassMinStartFadeDistance=0.0000",
                "iMinGrassSize=15",
                "",
                "[Decals]",
                "uMaxSkinDecalPerActor=60",
                "",
                "[LightingShader]",
                "fDecalLODFadeStart=0.45",
                "fDecalLODFadeEnd=0.5",
                "",
                "[Imagespace]",
                "iRadialBlurLevel=2",
                "",
                "[GeneralWarnings]",
                "SGeneralMasterMismatchWarning=",
                "",
                "[Fonts]",
                "sFontConfigFile=Interface\\FontConfig_ru.txt",
                "",
                "[Archive]",
                "sResourceArchiveList=Skyrim - Misc.bsa, Skyrim - Shaders.bsa, Skyrim - Interface.bsa, Skyrim - Animations.bsa, Skyrim - Meshes0.bsa, Skyrim - Meshes1.bsa, Skyrim - Sounds.bsa",
                "sResourceArchiveList2=Skyrim - Voices_ru0.bsa, Skyrim - Textures0.bsa, Skyrim - Textures1.bsa, Skyrim - Textures2.bsa, Skyrim - Textures3.bsa, Skyrim - Textures4.bsa, Skyrim - Textures5.bsa, Skyrim - Textures6.bsa, Skyrim - Textures7.bsa, Skyrim - Textures8.bsa, Skyrim - Patch.bsa",
                "bLoadArchiveInMemory=1",
                "sArchiveToLoadInMemoryList=Skyrim - Animations.bsa",
                "",
                "[Combat]",
                "fMagnetismStrafeHeadingMult=0.0",
                "fMagnetismLookingMult=0.0",
                "",
                "[Actor]",
                "bUseNavMeshForMovement=0",
                "",
                "[Papyrus]",
                "fPostLoadUpdateTimeMS=500.0",
                "bEnableLogging=0",
                "bEnableTrace=0",
                "bLoadDebugInformation=0"
            };
        }
        public static List<string> skyrimPrefsINI()
        {
            return new List<string>
            {
                "[Display]",
                "iShadowMapResolution=4096",
                "iNumFocusShadow=4",
                "fShadowDistance=10000.0000",
                "bVolumetricLightingEnable=1",
                "iVolumetricLightingQuality=2",
                "bScreenSpaceReflectionEnabled=1",
                "bSAOEnable=1",
                "bUsePrecipitationOcclusion=1",
                "bEnableImprovedSnow=0",
                "bEnableProjecteUVDiffuseNormals=1",
                "bToggleSparkles=1",
                "bIBLFEnable=1",
                "bUse64bitsHDRRenderTarget=1",
                "fMeshLODLevel1FadeDist=16896.0000",
                "fMeshLODLevel2FadeDist=16896.0000",
                "iAdapter=0",
                "iSize W=1280",
                "iSize H=720",
                "bUseTAA=1",
                "bFXAAEnabled=0",
                "bFull Screen=1",
                "bBorderless=1",
                "iNumSplits=2",
                "fInteriorShadowDistance=3000.0000",
                "ffocusShadowMapDoubleEveryXUnit=450.0000",
                "fDynamicDOFBlurMultiplier=1.0000",
                "fProjectedUVNormalDetailTilingScale=1.2000",
                "fProjectedUVDiffuseNormalTilingScale=0.5000",
                "bIndEnable=0",
                "bSAO_CS_Enable=0",
                "uBookRatio=2",
                "bForceCreateTarget=0",
                "iReflectionResolutionDivider=2",
                "iSaveGameScreenShotHeighWSt=192",
                "iSaveGameScreenShotWidthWS=320",
                "iSaveGameScreenShotHeight=192",
                "iSaveGameScreenShotWidth=256",
                "iShadowMaskQuarter=4",
                "fLightLODStartFade=3500.0000",
                "fLeafAnimDampenDistEnd=4600.0000",
                "fLeafAnimDampenDistStart=3600.0000",
                "fTreesMidLODSwitchDist=16896.0000",
                "fMeshLODFadePercentDefault=1.2000",
                "fMeshLODFadeBoundDefault=256.0000",
                "fMeshLODLevel2FadeTreeDistance=2048.0000",
                "fMeshLODLevel1FadeTreeDistance=2844.0000",
                "iVSyncPresentInterval=1",
                "fGamma=1.0000",
                "iScreenShotIndex=0",
                "bTreesReceiveShadows=1",
                "bDrawLandShadows=0",
                "iMaxSkinDecalsPerFrame=25",
                "iMaxDecalsPerFrame=100",
                "",
                "[Decals]",
                "bDecals=1",
                "bSkinnedDecals=1",
                "uMaxDecals=1000",
                "uMaxSkinDecals=100",
                "iMaxDecalsPerFrame=100",
                "iMaxSkinDecalsPerFrame=25",
                "",
                "[ImageSpace]",
                "bLensFlare=1",
                "bDoDepthOfField=1",
                "",
                "[LOD]",
                "fLODFadeOutMultObjects=15.0000",
                "fLODFadeOutMultActors=15.0000",
                "fLODFadeOutMultItems=10.0000",
                "fLODFadeOutMultSkyCell=1.0000",
                "",
                "[Grass]",
                "fGrassStartFadeDistance=7000.0000",
                "fGrassMaxStartFadeDistance=7000.0000",
                "fGrassMinStartFadeDistance=0.0000",
                "",
                "[General]",
                "uLargeRefLODGridSize=11",
                "fLightingOutputColourClampPostSpec=1.0000",
                "fLightingOutputColourClampPostEnv=1.0000",
                "fLightingOutputColourClampPostLit=1.0000",
                "bFreebiesSeen=1",
                "iStoryManagerLoggingEvent=-1",
                "bEnableStoryManagerLogging=0",
                "",
                "[TerrainManager]",
                "fTreeLoadDistance=75000.0000",
                "fBlockLevel0Distance=60000.0000",
                "fBlockLevel1Distance=90000.0000",
                "fBlockMaximumDistance=250000.0000",
                "fSplitDistanceMult=1.5000",
                "bShowLODInEditor=1",
                "",
                "[MAIN]",
                "fSkyCellRefFadeDistance=600000.0000",
                "bGamepadEnable=0",
                "bCrosshairEnabled=1",
                "fHUDOpacity=1.0000",
                "bSaveOnPause=0",
                "bSaveOnTravel=1",
                "bSaveOnWait=0",
                "bSaveOnRest=0",
                "",
                "[Bethesda.net]",
                "uPersistentUuidData3=2858525494",
                "uPersistentUuidData2=2819863935",
                "uPersistentUuidData1=3664658579",
                "uPersistentUuidData0=459413819",
                "",
                "[Interface]",
                "fMouseCursorSpeed=1.0000",
                "bDialogueSubtitles=0",
                "bGeneralSubtitles=0",
                "bShowCompass=1",
                "",
                "[GamePlay]",
                "bShowFloatingQuestMarkers=0",
                "bShowQuestMarkers=1",
                "iDifficulty=2",
                "",
                "[Controls]",
                "fMouseHeadingSensitivity=0.0250",
                "fGamepadHeadingSensitivity=0.6667",
                "bAlwaysRunByDefault=1",
                "bInvertYValues=0",
                "bGamePadRumble=1",
                "bUseKinect=0",
                "",
                "[Particles]",
                "iMaxDesired=750",
                "",
                "[SaveGame]",
                "fAutosaveEveryXMins=15.0000",
                "",
                "[AudioMenu]",
                "fAudioMasterVolume=1.0000",
                "",
                "[Clouds]",
                "fCloudLevel2Distance=262144.0000",
                "fCloudLevel1Distance=32768.0000",
                "fCloudLevel0Distance=16384.0000",
                "fCloudNearFadeDistance=9000.0000",
                "",
                "[Water]",
                "bUseWaterDisplacements=1",
                "bUseWaterRefractions=1",
                "bUseWaterReflections=1",
                "bUseWaterDepth=1",
                "",
                "[NavMesh]",
                "fObstacleAlpha=0.5000",
                "fCoverSideHighAlpha=0.8000",
                "fCoverSideLowAlpha=0.6500",
                "fEdgeFullAlpha=1.0000",
                "fEdgeHighAlpha=0.7500",
                "fEdgeLowAlpha=0.5000",
                "fTriangleFullAlpha=0.7000",
                "fTriangleHighAlpha=0.3500",
                "fTriangleLowAlpha=0.2000",
                "fLedgeBoxHalfHeight=25.0000",
                "fEdgeDistFromVert=10.0000",
                "fEdgeThickness=10.0000",
                "fPointSize=2.5000",
                "",
                "[Trees]",
                "bRenderSkinnedTrees=1",
                "uiMaxSkinnedTreesToRender=40"
            };
        }
        public static List<string> pluginsTXT()
        {
            return new List<string>
            {
                "*Unofficial Skyrim Special Edition Patch.esp",
                "*Alternate Start - Live Another Life.esp",
                "*Weather SVWI.esp"
            };
        }
    }
}