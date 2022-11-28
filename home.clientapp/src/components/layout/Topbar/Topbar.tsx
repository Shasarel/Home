import { TopbarButton } from "../TopbarButton/TopbarButton";
import './Topbar.css'

export const Topbar = () => {
    return (
        <header id="topbar">
            <TopbarButton name="Panel Administracyjny" route="admin" iconName="fa-solid fa-unlock-keyhole"></TopbarButton>
            <TopbarButton name="Ustawienia" route="settings" iconName="fa-solid fa-gear"></TopbarButton>
            <TopbarButton name="Wyloguj" route="logout" iconName="fa-solid fa-right-from-bracket"></TopbarButton>
        </header>
    );
}