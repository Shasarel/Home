import { useLocation } from "react-router-dom";
import { Icon } from "./Icon";

interface SidebarButtonProps {
    name: string,
    iconName: string,
    route: string
}

export const SidebarButton = ({ name, iconName, route }: SidebarButtonProps) => {
    const location = useLocation();
    const buttonClasses = "navbar-link" + (location.pathname == route ? " navbar-link-active" : "");

    return (
        <a href={route} className={buttonClasses}>
            <Icon iconName={iconName}></Icon>
            <span className="navbar-text">{name}</span>
        </a>
    );
}