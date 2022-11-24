import React, { useEffect, useState } from 'react';
import { Card } from '../shared/Card';
import { Fieldset } from '../shared/Fieldset';


export function Energy() {
    return (
        <Fieldset title="Energia">
            <Card title="Moc produkowana" value={2546} unit="W" percentage={55} percentageColor="green"></Card>
            <Card title="Moc pobierana" value={1346} unit="W" percentage={34} percentageColor="yellow"></Card>
            <Card title="Moc oddawana" value={1245} unit="W" percentage={20} percentageColor="yellow"></Card>
            <Card title="Moc zużywana" value={2538} unit="W" percentage={60} percentageColor="red"></Card>
            <Card title="Moc wykorzystywana" value={553} unit="W" percentage={20} percentageColor="yellow"></Card>
            <Card title="Moc magazynowana" value={853} unit="W" percentage={25} percentageColor="yellow"></Card>
        </Fieldset>
    );
}

async function data() {
}
