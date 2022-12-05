import { useParams } from "react-router-dom";
import { LoadComponendWithData } from "../../../core/LoadComponentWithData";
import { EnergyHistoryDto } from "../../../dtos/EnergyHistoryDto";
import { Card } from "../../shared/Card/Card";
import { ElectricityChart } from "../../shared/Chart/ElectricityChart";
import { Fieldset } from "../../shared/Fieldset/Fieldset";

export function EnergyHistory() {
    const { from, to } = useParams();

    return LoadComponendWithData(`api/energy/history?from=${from}&&to=${to}`, ((data: EnergyHistoryDto) =>
    (

        <div className="flex-column-center"> 
            <Fieldset title="Energia">
                <Card title="Wyprodukowana" value={data.energy.production} unit="kWh" maxValue={data.energyPrevious.production} percentageColor="green"></Card>
                <Card title="Zużyta" value={data.energy.consumption} unit="kWh" maxValue={data.energyPrevious.consumption} percentageColor="red"></Card>
                <Card title="Wykorzystana" value={data.energy.use} unit="kWh" maxValue={data.energyPrevious.use} percentageColor="yellow"></Card>
                <Card title="Pobrana" value={data.energy.import} unit="kWh" maxValue={data.energyPrevious.import} percentageColor="yellow"></Card>
                <Card title="Oddana" value={data.energy.export} unit="kWh" maxValue={data.energyPrevious.export} percentageColor="yellow"></Card>
                <Card title="Zmagazynowana" value={data.energy.store} unit="kWh" maxValue={data.energyPrevious.store} percentageColor="yellow"></Card>
            </Fieldset>
            <ElectricityChart chartData={data.chartData}></ElectricityChart>
        </div>
    )));
}