import { Energy } from "./components/pages/Energy/Energy";
import { EnergyHistory } from "./components/pages/Energy/EnergyHistory";
import { Home } from "./components/pages/Home";
import { Meteo } from "./components/pages/Meteo/Meteo";
import { MeteoHistory } from "./components/pages/Meteo/MeteoHistory";

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
        element: <Meteo/>
    },
    MeteoHistory: {
        index: false,
        path: "/meteo/history/:from/:to",
        title: "Meteo - historia",
        element: <MeteoHistory />
    },
}

export default AppRoutes;
