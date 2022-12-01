import { BooleanLiteral } from "typescript";
import { HideSidebarButton } from "../TopbarButton/HideSidebarButton";
import { TopbarButton } from "../TopbarButton/TopbarButton";
import './Topbar.css'

type TopbarProps = {
    toogleSidebar: (enabled: boolean) => void;
}

export const Topbar = ({ toogleSidebar }: TopbarProps) => {
    return (
        <header id="topbar">
            <HideSidebarButton iconName="fa-solid fa-bars" toggleSidebar={toogleSidebar}></HideSidebarButton>
            <div id="topbar-buttons" onClick={() => toogleSidebar(false)}>
                <TopbarButton name="Panel Administracyjny" route="admin" iconName="fa-solid fa-unlock-keyhole"></TopbarButton>
                <TopbarButton name="Ustawienia" route="settings" iconName="fa-solid fa-gear"></TopbarButton>
                <TopbarButton name="Wyloguj" route="logout" iconName="fa-solid fa-right-from-bracket"></TopbarButton>
            </div>
        </header>
    );
}