import { useParams } from "react-router-dom";
import { LoadComponendWithData } from "../../../core/LoadComponentWithData";
import { MeteoChartData } from "../../../dtos/MeteoChartData";
import { MeteoChart } from "../../shared/Chart/MeteoChart";

export function MeteoHistory() {
    const { from, to } = useParams();

    return LoadComponendWithData(`api/meteo/history?from=${from}&&to=${to}`, ((data: MeteoChartData) =>
    (
        <div className="flex-column-center">
            <MeteoChart chartData={data.temperature} labels={data.labels} title="Temperatura (°C)" />
            <MeteoChart chartData={data.pressure} labels={data.labels} title="Ciśnienie atmosferyczne (hPa)" />
            <MeteoChart chartData={data.dust} labels={data.labels} title="Pył zawieszony (µg/m³)" />
        </div>
    )));
}