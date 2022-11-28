import { Icon } from '../Icon/Icon';
import './TopbarButton.css'

interface TopbarButtonProps {
    name: string,
    route: string,
    iconName: string
}

export function TopbarButton({ name, route, iconName }: TopbarButtonProps) {
    return (
        <a href={ route }>
            <div className="navbar-link topbar-button">
                <Icon iconName={iconName}></Icon>
                <span className="topbar-text">{name}</span>
            </div>
        </a>
    );
}
