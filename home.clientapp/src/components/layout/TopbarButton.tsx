import React from 'react';
import { Sidebar } from './Sidebar'


interface TopbarButtonProps {
    name: string,
    route: string
}

export function TopbarButton({ name, route }: TopbarButtonProps) {
    return (
        <a href={ route }>
            <div className="navbar-link topbar-button"> {name}</div>
        </a>
    );
}
