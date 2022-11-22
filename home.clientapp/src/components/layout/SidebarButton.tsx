import { Icon } from "./Icon";

interface SidebarButtonProps {
    name: string,
    iconName: string,
    route: string
}

export const SidebarButton = ({ name, iconName, route }: SidebarButtonProps) => {
    return (
        <a href={route} className="navbar-link">
            <Icon iconName={iconName}></Icon>
            <span className="navbar-text">{name}</span>
        </a>
    );
}