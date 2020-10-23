/////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Audiokinetic Wwise generated include file. Do not edit.
//
/////////////////////////////////////////////////////////////////////////////////////////////////////

#ifndef __WWISE_IDS_H__
#define __WWISE_IDS_H__

#include <AK/SoundEngine/Common/AkTypes.h>

namespace AK
{
    namespace EVENTS
    {
        static const AkUniqueID AI_BUTTON_SELECT = 100709541U;
        static const AkUniqueID AI_BUTTON_SELECT_BACK = 2964552185U;
        static const AkUniqueID AI_PROCESSING = 2569711091U;
        static const AkUniqueID CHANGE_TO_DIRT = 1676133841U;
        static const AkUniqueID CHANGE_TO_STONE = 337775249U;
        static const AkUniqueID DOOR_OPEN = 535830432U;
        static const AkUniqueID FAIL = 2596272617U;
        static const AkUniqueID FOOTSTEP = 1866025847U;
        static const AkUniqueID LADDER_CLIMB = 1707141479U;
        static const AkUniqueID LADDER_DESCEND = 3610060586U;
        static const AkUniqueID MENU_BUTTON_BACK = 1284910139U;
        static const AkUniqueID MENU_BUTTON_SELECT = 4007661982U;
        static const AkUniqueID MINECART = 10183550U;
        static const AkUniqueID MINECART_LOADING = 3688866299U;
        static const AkUniqueID NOTIFICATION_1 = 1218670268U;
        static const AkUniqueID NOTIFICATION_2 = 1218670271U;
        static const AkUniqueID OUTSIDE_ATMOS = 3460054317U;
        static const AkUniqueID PASS = 1627031574U;
        static const AkUniqueID PLANT_HARVEST = 3735191866U;
        static const AkUniqueID PLANT_HARVEST_CHIME = 3450230255U;
        static const AkUniqueID PLAYBEDROOMMUSIC = 1586650550U;
        static const AkUniqueID PLAYGREENHOUSEMUSIC = 1744321513U;
        static const AkUniqueID PLAYMUSIC = 417627684U;
        static const AkUniqueID PLAYOUTDOORSMUSIC = 2392128485U;
        static const AkUniqueID PLAYTERMINALMUSIC = 3425704496U;
        static const AkUniqueID PLAYTITLESCREENMUSIC = 2109147180U;
        static const AkUniqueID SEED_PLANTING = 2449075236U;
        static const AkUniqueID STOPALL = 3086540886U;
        static const AkUniqueID WATER = 2654748154U;
        static const AkUniqueID WATER_DROPLET_ATMOS = 909052898U;
        static const AkUniqueID WOOD_CHOP = 1483562389U;
    } // namespace EVENTS

    namespace STATES
    {
        namespace FOOTSTEP_MATERIAL
        {
            static const AkUniqueID GROUP = 684570577U;

            namespace STATE
            {
                static const AkUniqueID DIRT = 2195636714U;
                static const AkUniqueID NONE = 748895195U;
                static const AkUniqueID STONE = 1216965916U;
            } // namespace STATE
        } // namespace FOOTSTEP_MATERIAL

        namespace MUSIC
        {
            static const AkUniqueID GROUP = 3991942870U;

            namespace STATE
            {
                static const AkUniqueID BASEMENT = 1413413702U;
                static const AkUniqueID BEDROOM = 3788924735U;
                static const AkUniqueID GREENHOUSE = 4238926114U;
                static const AkUniqueID NONE = 748895195U;
                static const AkUniqueID OUTSIDE = 438105790U;
                static const AkUniqueID TERMINAL = 414380065U;
            } // namespace STATE
        } // namespace MUSIC

    } // namespace STATES

    namespace SWITCHES
    {
        namespace MUSIC
        {
            static const AkUniqueID GROUP = 3991942870U;

            namespace SWITCH
            {
                static const AkUniqueID BASEMENT = 1413413702U;
                static const AkUniqueID BEDROOM = 3788924735U;
                static const AkUniqueID GREENHOUSE = 4238926114U;
                static const AkUniqueID OUTSIDE = 438105790U;
                static const AkUniqueID TERMINAL = 414380065U;
            } // namespace SWITCH
        } // namespace MUSIC

    } // namespace SWITCHES

    namespace GAME_PARAMETERS
    {
        static const AkUniqueID MASTERVOLUME = 2918011349U;
        static const AkUniqueID MUSICVOLUME = 2346531308U;
        static const AkUniqueID SFXVOLUME = 988953028U;
        static const AkUniqueID TREEHEALTH = 1985814903U;
    } // namespace GAME_PARAMETERS

    namespace BANKS
    {
        static const AkUniqueID INIT = 1355168291U;
        static const AkUniqueID AI_TERMINAL = 1636586622U;
        static const AkUniqueID GREENHOUSE = 4238926114U;
        static const AkUniqueID MENU = 2607556080U;
        static const AkUniqueID OUTDOOR = 144697359U;
        static const AkUniqueID PLAYER = 1069431850U;
    } // namespace BANKS

    namespace BUSSES
    {
        static const AkUniqueID MASTER_AUDIO_BUS = 3803692087U;
        static const AkUniqueID MUSIC_AUDIO_BUS = 493417818U;
        static const AkUniqueID SFX_AUDIO_BUS = 4084199202U;
    } // namespace BUSSES

    namespace AUDIO_DEVICES
    {
        static const AkUniqueID NO_OUTPUT = 2317455096U;
        static const AkUniqueID SYSTEM = 3859886410U;
    } // namespace AUDIO_DEVICES

}// namespace AK

#endif // __WWISE_IDS_H__
