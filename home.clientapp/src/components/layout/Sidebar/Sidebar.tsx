import AppRoutes from "../../../AppRoutes";
import { Logo } from "../Logo/Logo";
import { SidebarButton } from "../SidebarButton/SidebarButton";
import './Sidebar.css'

export const Sidebar = () => {
    return (
        <div id="sidebar">
            <Logo></Logo>
            <nav>
                <SidebarButton route={AppRoutes.Home} iconName="fas fa-th-large"></SidebarButton>
                <SidebarButton route={AppRoutes.Energy} iconName="fas fa-bolt"></SidebarButton>
                <SidebarButton route={AppRoutes.Blinds} iconName="far fa-window-maximize"></SidebarButton>
                <SidebarButton route={AppRoutes.Meteo} iconName="fas fa-temperature-low"></SidebarButton>
            </nav>
        </div>
    );
}