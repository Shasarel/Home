import { HomeDto } from '../../dtos/HomeDto';
import { LoadComponendWithData } from '../../core/LoadComponentWithData';
import { Fieldset } from '../shared/Fieldset/Fieldset';
import { Card } from '../shared/Card/Card';


export function Home() {
    return LoadComponendWithData("api/home", ((data: HomeDto) =>
    (
        <Fieldset title="Energia">
            <Card title="Dzienna produkcja" value={data.energyToday.production} unit="kWh" percentage={50} percentageColor="green"></Card>
            <Card title="Dzienne zużycie" value={data.energyToday.consumption} unit="kWh" percentage={50} percentageColor="red"></Card>
            <Card title="Dzienny bilans" value={data.energyToday.store} unit="kWh" percentage={50} percentageColor="red"></Card>
            <Card title="Całkowita produkcja" value={data.energyAll.production} unit="kWh" percentage={50} percentageColor="yellow"></Card>
            <Card title="Całkowite zużycie" value={data.energyAll.consumption} unit="kWh" percentage={50} percentageColor="yellow"></Card>
            <Card title="Całkowity blians" value={data.energyAll.store} unit="kWh" percentage={50} percentageColor="yellow"></Card>
        </Fieldset>
        )))
}
