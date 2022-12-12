import { Icon } from '../Icon/Icon';
import './TopbarButton.css'

interface HideSidebarButtonProps {
    iconName: string
    toggleSidebarAll: () => void;
}

export function HideSidebarButton({ iconName, toggleSidebarAll }: HideSidebarButtonProps) {
    return (
        <div className="topbar-button hide-sidebar-button" onClick={() => toggleSidebarAll()}>
            <Icon iconName={iconName}></Icon>
        </div>
    );
} 