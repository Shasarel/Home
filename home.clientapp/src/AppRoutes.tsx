import { Energy } from "./components/pages/Energy";
import { Home } from "./components/pages/Home";

const AppRoutes=
{
    Home: {
        index: true,
        path: "/",
        title: "Strona główna",
        element: <Home />
    },
    Energy: {
        index: false,
        path: "/energy",
        title: "Energia",
        element: <Energy />
    },
    Blinds: {
        index: false,
        path: "/blinds",
        title: "Rolety",
        element: <Energy />
    },
    Meteo: {
        index: false,
        path: "/meteo",
        title: "Meteo",
        element: <Energy />
    },
}

export default AppRoutes;
