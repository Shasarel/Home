import '../../../node_modules/@fortawesome/fontawesome-free/css/all.min.css'

interface IconProps {
    iconName: string
}

export const Icon = ({ iconName }: IconProps) => {
    return (
        <div className="navbar-icon">
            <i className={iconName}></i>
        </div>
    );
}