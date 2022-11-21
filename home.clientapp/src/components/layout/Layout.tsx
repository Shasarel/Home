import React from 'react';
import '../../../node_modules/@fortawesome/fontawesome-free/css/all.min.css'
import { Sidebar } from './Sidebar'

type LayoutProps = {
    children: React.ReactNode;
}

export function Layout({ children }: LayoutProps) {
    return (
        <div id="main-wrapper">
            <Sidebar></Sidebar>
            <div id="page-wrapper">
            <header id="topbar">
                <div id="adminTabButton" className="navbar-link topbar-button"> Panel administracyjny</div>
                <div id="settingsTabButton" className="navbar-link topbar-button">Ustawienia</div>
            </header>
                <div id="page-container">
                    {children}
                </div>
            </div>
        </div>
    );
}
