import { TopbarButton } from "./TopbarButton";

export const Topbar = () => {
    return (
        <header id="topbar">
            <TopbarButton name="Panel Administracyjny" route="admin"></TopbarButton>
            <TopbarButton name="Ustawienia" route="settings"></TopbarButton>
            <TopbarButton name="Wyloguj" route="logout"></TopbarButton>
        </header>
    );
}