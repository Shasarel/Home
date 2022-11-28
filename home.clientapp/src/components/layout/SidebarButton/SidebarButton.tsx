import { NavLink, useLocation } from "react-router-dom";
import { Route } from "../../../core/Route";
import { Icon } from "../Icon/Icon";
import './SidebarButton.css'

interface SidebarButtonProps {
    route: Route,
    iconName: string
}

export const SidebarButton = ({ route, iconName}: SidebarButtonProps) => {
    const location = useLocation();
    let navLinkClasses = "sidebar-button";

    if ((route.path !== '/' && (location.pathname.startsWith(route.path))) ||
        (route.path === '/' && location.pathname === "/"))
        navLinkClasses += " sidebar-button-active";

    return (
        <NavLink className={navLinkClasses} to={route.path}>
            <Icon iconName={iconName}></Icon>
            <span className="sidebar-button-text">{route.title}</span>
        </NavLink>
    );
}