import { Logo } from "../Logo/Logo";
import { SidebarButton } from "../SidebarButton/SidebarButton";
import './Sidebar.css'

export const Sidebar = () => {
    return (
        <div id="sidebar">
            <Logo></Logo>
                <nav>
                    <SidebarButton name="Strona główna" iconName="fas fa-th-large" route="/"></SidebarButton>
                    <SidebarButton name="Energia" iconName="fas fa-bolt" route="/energy"></SidebarButton>
                    <SidebarButton name="Rolety" iconName="far fa-window-maximize" route="meteo"></SidebarButton>
                    <SidebarButton name="Stacja meteo" iconName="fas fa-temperature-low" route="blinds"></SidebarButton>
                </nav>
            </div>
    );
}