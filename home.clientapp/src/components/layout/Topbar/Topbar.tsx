import { HideSidebarButton } from "../TopbarButton/HideSidebarButton";
import { TopbarButton } from "../TopbarButton/TopbarButton";
import './Topbar.css'

type TopbarProps = {
    toggleSidebarPhone: (isEnabled: boolean) => void;
    toggleSidebarAll: () => void
}

export const Topbar = ({ toggleSidebarPhone, toggleSidebarAll }: TopbarProps) => {
    return (
        <header id="topbar">
            <HideSidebarButton iconName="fa-solid fa-bars" toggleSidebarAll={toggleSidebarAll}></HideSidebarButton>
            <div id="topbar-buttons" onClick={() => toggleSidebarPhone(false)}>
                <TopbarButton name="Panel Administracyjny" route="admin" iconName="fa-solid fa-unlock-keyhole"></TopbarButton>
                <TopbarButton name="Ustawienia" route="settings" iconName="fa-solid fa-gear"></TopbarButton>
                <TopbarButton name="Wyloguj" route="logout" iconName="fa-solid fa-right-from-bracket"></TopbarButton>
            </div>
        </header>
    );
}