import { useLocation } from "react-router-dom";
import AppRoutes from "../../AppRoutes";

export function Title() {
    const location = useLocation();
    const title = AppRoutes.filter(x => x.path == location.pathname)[0].title;
    return (
        <div className="page-title">{title}</div>
    );
}
