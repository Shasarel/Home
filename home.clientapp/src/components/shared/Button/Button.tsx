import { Link } from "react-router-dom";
import './Button.css'

interface ButtonProps {
    route: string,
    title: string
}

export function Button ({ route, title }: ButtonProps) {
    return (
        <div className="button-wrapper">
            <Link to={route} className="button">
                {title}
            </Link>
        </div>
    );
}