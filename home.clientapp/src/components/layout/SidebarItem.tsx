import { Icon } from "./Icon";

interface SidebarItemProps {
    name: string,
    iconName: string,
    route: string
}

export const SidebarItem = ({ name, iconName, route }: SidebarItemProps) => {
    return (
        <a href={route} className="navbar-link">
            <Icon iconName={iconName}></Icon>
            <span className="navbar-text">{name}</span>
        </a>
    );
}