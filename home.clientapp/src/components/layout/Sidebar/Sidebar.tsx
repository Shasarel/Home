import AppRoutes from "../../../AppRoutes";
import { SidebarButton } from "../SidebarButton/SidebarButton";
import './Sidebar.css'

type SidebarProps = {
    toggleSidebarPhone: (isEnabled: boolean) => void;
    sidebarEnabledPhone: boolean;
    sidebarEnabledDesktop: boolean;
}

export const Sidebar = ({ toggleSidebarPhone, sidebarEnabledPhone, sidebarEnabledDesktop }: SidebarProps) => {

    var className = sidebarEnabledPhone ? "" : "sidebar-disabled-phone";
    className += sidebarEnabledDesktop ? "" : " sidebar-disabled-desktop";


    return (
        <div id="sidebar" className={className} onClick={() => toggleSidebarPhone(false)}>
            <nav>
                <SidebarButton route={AppRoutes.Home} iconName="fas fa-home"></SidebarButton>
                <SidebarButton route={AppRoutes.Energy} iconName="fas fa-bolt"></SidebarButton>
                <SidebarButton route={AppRoutes.Blinds} iconName="far fa-window-maximize"></SidebarButton>
                <SidebarButton route={AppRoutes.Meteo} iconName="fas fa-temperature-low"></SidebarButton>
            </nav>
        </div>
    );
}