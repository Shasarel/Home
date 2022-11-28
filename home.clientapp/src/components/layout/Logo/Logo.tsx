import { Icon } from "../Icon/Icon";
import './Logo.css'

export const Logo = () => {
    return (
        <a id="logo" className="logo" href="/">
            <Icon iconName="fas fa-home"></Icon>
            <span id="logo-text">
                Home
            </span>
        </a>
    );
}