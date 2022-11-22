import { Icon } from "./Icon";

export const Logo = () => {
    return (
        <a id="logo" href="/">
            <Icon iconName="fas fa-home"></Icon>
            <span id="logo-text">
                Home
            </span>
        </a>
    );
}