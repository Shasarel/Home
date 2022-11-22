import { Energy } from "./components/pages/Energy";
import { Home } from "./components/pages/Home";

const AppRoutes = [
    {
        index: true,
        element: <Home />
    }, {
        path: "/energy",
        element: <Energy />
    }
];

export default AppRoutes;
