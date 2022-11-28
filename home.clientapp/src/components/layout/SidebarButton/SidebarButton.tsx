import { useLocation } from "react-router-dom";
import { Icon } from "../Icon/Icon";
import './SidebarButton.css'

interface SidebarButtonProps {
    name: string,
    iconName: string,
    route: string
}

export const SidebarButton = ({ name, iconName, route }: SidebarButtonProps) => {
    const location = useLocation();
    const buttonClasses = "sidebar-button" + (location.pathname == route ? " sidebar-button-active" : "");

    return (
        <a href={route} className={buttonClasses}>
            <Icon iconName={iconName}></Icon>
            <span className="sidebar-button-text">{name}</span>
        </a>
    );
}