import React, { useState } from 'react';
import { Sidebar } from '../Sidebar/Sidebar';
import { Title } from '../Title/Title';
import { Topbar } from '../Topbar/Topbar';
import "./Layout.css"

type LayoutProps = {
    children: React.ReactNode;
}

export function Layout({ children }: LayoutProps) {
    const [sidebarEnabledDesktop, setSidebarEnabledDesktop] = useState<boolean>(true);
    const [sidebarEnabledPhone, setSidebarEnabledPhone] = useState<boolean>(false);

    const ToggleSidebarAll = () => {
        setSidebarEnabledDesktop(!sidebarEnabledDesktop);
        setSidebarEnabledPhone(!sidebarEnabledPhone);
    }; 

    const ToggleSidebarPhone = (isEnabled: boolean) => {
        setSidebarEnabledPhone(isEnabled);
    };

    return (
        <div id="layout">
            <Topbar toggleSidebarAll={ToggleSidebarAll} toggleSidebarPhone={ToggleSidebarPhone}></Topbar>
            <Sidebar toggleSidebarPhone={ToggleSidebarPhone} sidebarEnabledDesktop={sidebarEnabledDesktop} sidebarEnabledPhone={sidebarEnabledPhone}></Sidebar>
            <div id="page-wrapper" className={sidebarEnabledDesktop ? "" : "page-wrapper-sidebar-disabled"} onClick={() => ToggleSidebarPhone(false)}>
                <div id="page-container">
                    <Title></Title>
                    {children}
                </div>
            </div>
        </div>
    );
}