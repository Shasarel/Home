import React, { useState } from 'react';
import { Sidebar } from '../Sidebar/Sidebar';
import { Title } from '../Title/Title';
import { Topbar } from '../Topbar/Topbar';
import "./Layout.css"

type LayoutProps = {
    children: React.ReactNode;
}

export function Layout({ children }: LayoutProps) {
    const [sidebarEnabled, setSidebarEnabled] = useState<boolean>(false);

    const ToggleSidebar = (enabled: boolean) => {
        setSidebarEnabled(enabled);
    };

    return (
        <div id="layout">
            <Topbar toogleSidebar={ToggleSidebar}></Topbar>
            {sidebarEnabled ? <Sidebar toggleSidebar={ToggleSidebar}></Sidebar> : ""}
            <div id="page-wrapper" onClick={() => ToggleSidebar(false)}>
                <div id="page-container">
                    <Title></Title>
                    {children}
                </div>
            </div>
        </div>
    );
}