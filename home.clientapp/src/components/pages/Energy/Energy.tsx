import { LoadComponendWithData } from '../../../core/LoadComponentWithData';
import { EnergyDto } from '../../../dtos/Energy/EnergyDto';
import { CardBar } from '../../shared/Card/CardBar';
import { Fieldset } from '../../shared/Fieldset/Fieldset';
import AppRoutes from '../../../AppRoutes';
import { NavigateToHistory } from '../../shared/NavigateToHistory/NavigateToHistory';

const maxPowerProduction = 8500;

export function Energy() {
    return <LoadComponendWithData url="api/energy/currentpower" componentCallback={((data: EnergyDto) =>
    (
        <div className="flex-column-center">
            <Fieldset title="Moc chwilowa">
                <CardBar title="Produkowana" value={data.production} unit="W" maxValue={maxPowerProduction} percentageColor="green"></CardBar>
                <CardBar title="Pobierana" value={data.import} unit="W" maxValue={maxPowerProduction} percentageColor="yellow"></CardBar>
                <CardBar title="Oddawana" value={data.export} unit="W" maxValue={maxPowerProduction} percentageColor="yellow"></CardBar>
                <CardBar title="Zużywana" value={data.consumption} unit="W" maxValue={maxPowerProduction} percentageColor="red"></CardBar>
                <CardBar title="Wykorzystywana" value={data.use} unit="W" maxValue={maxPowerProduction} percentageColor="yellow"></CardBar>
                <CardBar title="Magazynowana" value={data.store} unit="W" maxValue={maxPowerProduction} percentageColor="yellow"></CardBar>
            </Fieldset>
            <NavigateToHistory path={AppRoutes.EnergyHistory.path} />
        </div>
    ))} interval={5000}/>;
}
