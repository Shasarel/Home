import { useLocation } from "react-router-dom";
import AppRoutes from "../../../AppRoutes";
import "./Title.css"

export function Title() {
    const location = useLocation();
    const route = Object.values(AppRoutes).filter(x => x.path === location.pathname);
    let title;

    if (route.length > 0)
        title = route[0].title;

    return (
        <div className="page-title">{title}</div>
    );
}
