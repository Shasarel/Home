import '../../../../node_modules/@fortawesome/fontawesome-free/css/all.min.css'
import './Icon.css'

interface IconProps {
    iconName: string
}

export const Icon = ({ iconName }: IconProps) => {
    const className = iconName + ' icon';
    return (
        <i className={className}></i>
    );
}