import { SidebarItem } from "./SidebarItem";

export const Sidebar = () => {
    return (
             <div id="sidebar">
                <a id="logo" href="/">
                    <b id="logo-icon">
                        <i className="fas fa-home"></i>
                    </b>
                    <span id="logo-text">
                        Home
                    </span>
                </a>
                <nav id="navbar">
                    <SidebarItem name="Strona główna" iconName="fas fa-th-large" route="/"></SidebarItem>
                    <SidebarItem name="Energia" iconName="fas fa-bolt" route="energy"></SidebarItem>
                    <SidebarItem name="Rolety" iconName="far fa-window-maximize" route="meteo"></SidebarItem>
                    <SidebarItem name="Stacja meteo" iconName="fas fa-temperature-low" route="blinds"></SidebarItem>
                </nav>
            </div>
    );
}