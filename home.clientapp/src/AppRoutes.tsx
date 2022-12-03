import { Energy } from "./components/pages/Energy/Energy";
import { EnergyHistory } from "./components/pages/EnergyHistory/EnergyHistory";
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
    EnergyHistory: {
        index: false,
        path: "/energy/history/:from/:to",
        title: "Energia - historia",
        element: <EnergyHistory />
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
