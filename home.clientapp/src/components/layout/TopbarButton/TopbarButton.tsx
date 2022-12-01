import { NavLink } from 'react-router-dom';
import { Icon } from '../Icon/Icon';
import './TopbarButton.css'

interface TopbarButtonProps {
    name: string,
    route: string,
    iconName: string
}

export function TopbarButton({ name, route, iconName }: TopbarButtonProps) {

    let className = "topbar-button";

    if (route === "logout")
        className += " topbar-button-logout";

    return (
        <div className={className}>
            <NavLink to={route}>
                <div className="topbar-button-wrapper">
                    <Icon iconName={iconName}></Icon>
                    <span className="topbar-text">{name}</span>
                </div>
            </NavLink>
        </div>
    );
}
