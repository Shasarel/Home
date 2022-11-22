import { SidebarButton } from "./SidebarButton";

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
                    <SidebarButton name="Strona główna" iconName="fas fa-th-large" route="/"></SidebarButton>
                    <SidebarButton name="Energia" iconName="fas fa-bolt" route="energy"></SidebarButton>
                    <SidebarButton name="Rolety" iconName="far fa-window-maximize" route="meteo"></SidebarButton>
                    <SidebarButton name="Stacja meteo" iconName="fas fa-temperature-low" route="blinds"></SidebarButton>
                </nav>
            </div>
    );
}