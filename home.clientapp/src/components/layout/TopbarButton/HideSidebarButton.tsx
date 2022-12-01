import ReactDOM from 'react-dom';
import { Icon } from '../Icon/Icon';
import './TopbarButton.css'

interface HideSidebarButtonProps {
    iconName: string
    toggleSidebar: (enabled: boolean) => void;
}

export function HideSidebarButton({ iconName, toggleSidebar }: HideSidebarButtonProps) {
    return (
        <div className="topbar-button hide-sidebar-button" onClick={() => toggleSidebar(true)}>
            <Icon iconName={iconName}></Icon>
        </div>
    );
} 