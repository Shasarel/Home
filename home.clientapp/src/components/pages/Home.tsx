import { HomeDto } from '../../dtos/HomeDto';
import { Card } from '../shared/Card';
import { Fieldset } from '../shared/Fieldset';
import { LoadComponendWithData } from '../../core/LoadComponentWithData';


export function Home() {
    return LoadComponendWithData("api/home2", ((data: HomeDto) =>
    (
        <Fieldset title="Energia">
                <Card title="Dzienna produkcja" value={data.energyToday.production} unit="kWh" percentage={50} percentageColor="green"></Card>
                <Card title="Dzienne zużycie" value={data.energyToday.consumption} unit="kWh" percentage={50} percentageColor="red"></Card>
                <Card title="Dzienny bilans" value={data.energyToday.store} unit="kWh" percentage={50} percentageColor="red"></Card>
                <Card title="Całkowity blians" value={data.energyAll.store} unit="kWh" percentage={50} percentageColor="yellow"></Card>
            </Fieldset>
        )))
}
