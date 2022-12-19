import { useParams } from "react-router-dom";
import { LoadComponendWithData } from "../../../core/LoadComponentWithData";
import { EnergyHistoryDto } from "../../../dtos/Energy/EnergyHistoryDto";
import { CardBar } from "../../shared/Card/CardBar";
import { ElectricityChart } from "../../shared/Chart/ElectricityChart";
import { Fieldset } from "../../shared/Fieldset/Fieldset";

export function EnergyHistory() {
    const { from, to } = useParams();

    return <LoadComponendWithData url={`api/energy/history?from=${from}&&to=${to}`} componentCallback={((data: EnergyHistoryDto) =>
    (
        <div className="flex-column-center">
            <Fieldset title="Energia">
                <CardBar title="Wyprodukowana" value={data.energy.production} unit="kWh" maxValue={data.energyPrevious.production} percentageColor="green"></CardBar>
                <CardBar title="Zużyta" value={data.energy.consumption} unit="kWh" maxValue={data.energyPrevious.consumption} percentageColor="red"></CardBar>
                <CardBar title="Wykorzystana" value={data.energy.use} unit="kWh" maxValue={data.energyPrevious.use} percentageColor="yellow"></CardBar>
                <CardBar title="Pobrana" value={data.energy.import} unit="kWh" maxValue={data.energyPrevious.import} percentageColor="yellow"></CardBar>
                <CardBar title="Oddana" value={data.energy.export} unit="kWh" maxValue={data.energyPrevious.export} percentageColor="yellow"></CardBar>
                <CardBar title="Zmagazynowana" value={data.energy.store} unit="kWh" maxValue={data.energyPrevious.store} percentageColor="yellow"></CardBar>
            </Fieldset>
            <ElectricityChart chartData={data.chartData}></ElectricityChart>
        </div>
    ))}/>
}