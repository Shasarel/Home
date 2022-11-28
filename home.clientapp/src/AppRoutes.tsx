import { Energy } from "./components/pages/Energy";
import { Home } from "./components/pages/Home";

const AppRoutes = [
    {
        index: true,
        path: "/",
        element: <Home />,
        title: "Strona główna",
    }, {
        path: "/energy",
        element: <Energy />,
        title: "Energia"
    }
];

export default AppRoutes;
