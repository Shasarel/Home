import { LoadComponendWithData } from '../../core/LoadComponentWithData';
import { EnergyDto } from '../../dtos/EnergyDto';
import { Card } from '../shared/Card/Card';
import { Fieldset } from '../shared/Fieldset/Fieldset';

export function Energy() { 
    const maxPowerProduction = 8500;
    return LoadComponendWithData("api/energy/currentpower", ((data: EnergyDto) =>
    (
        <Fieldset title="Energia">
            <Card title="Moc produkowana" value={data.production} unit="W" maxValue={maxPowerProduction} percentageColor="green"></Card>
            <Card title="Moc pobierana" value={data.import} unit="W" maxValue={maxPowerProduction} percentageColor="yellow"></Card>
            <Card title="Moc oddawana" value={data.export} unit="W" maxValue={maxPowerProduction} percentageColor="yellow"></Card>
            <Card title="Moc zużywana" value={data.consumption} unit="W" maxValue={maxPowerProduction} percentageColor="red"></Card>
            <Card title="Moc wykorzystywana" value={data.use} unit="W" maxValue={maxPowerProduction} percentageColor="yellow"></Card>
            <Card title="Moc magazynowana" value={data.store} unit="W" maxValue={maxPowerProduction} percentageColor="yellow"></Card>
        </Fieldset>
    )), 5000);
}