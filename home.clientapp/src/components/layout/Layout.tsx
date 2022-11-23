﻿import React from 'react';
import { Sidebar } from './Sidebar'
import { Title } from './Title';
import { Topbar } from './Topbar';

type LayoutProps = {
    children: React.ReactNode;
}

export function Layout({ children}: LayoutProps) {
    return (
        <div id="layout">
            <Sidebar></Sidebar>
            <div id="page-wrapper">
                <Topbar></Topbar>
                <div id="page-container">
                    <Title></Title>
                    {children}
                </div>
            </div>
        </div>
    );
}
