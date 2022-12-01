import AppRoutes from "../../../AppRoutes";
import { SidebarButton } from "../SidebarButton/SidebarButton";
import './Sidebar.css'

type SidebarProps = {
    toggleSidebar: (enabled: boolean) => void;
}

export const Sidebar = ({ toggleSidebar }: SidebarProps) => {
    return (
        <div id="sidebar" onClick={() => toggleSidebar(false)}>
            <nav>
                <SidebarButton route={AppRoutes.Home} iconName="fas fa-home"></SidebarButton>
                <SidebarButton route={AppRoutes.Energy} iconName="fas fa-bolt"></SidebarButton>
                <SidebarButton route={AppRoutes.Blinds} iconName="far fa-window-maximize"></SidebarButton>
                <SidebarButton route={AppRoutes.Meteo} iconName="fas fa-temperature-low"></SidebarButton>
            </nav>
        </div>
    );
}