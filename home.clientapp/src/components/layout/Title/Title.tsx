import { matchPath, useLocation } from "react-router-dom";
import AppRoutes from "../../../AppRoutes";
import "./Title.css"

export function Title() {
    const location = useLocation();
    let title;

    const route = Object.values(AppRoutes)
        .map((route) => matchPath(route.path, location.pathname))
        .filter(x => x !== null);

    if (route.length > 0) {
        title = Object.values(AppRoutes)
            .filter(x => x.path === route[0]?.pattern.path)[0]
            .title;
    }

    return (
        <div className="page-title">{title}</div>
    );
}
