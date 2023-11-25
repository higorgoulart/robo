import React, {useEffect, useState} from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import './Home.css';
import {Alert} from "reactstrap";
import {Robot} from "./Robot";
import {Card} from "./Card";

export function Home() {
    const [robo, setRobo] = useState({
        "cabeca": {
            "rotacao": "EmRepouso", 
            "inclinacao": "EmRepouso"
        },
        "bracoEsquerdo": {
            "cotovelo": "EmRepouso",
            "pulso": "EmRepouso"
        },
        "bracoDireito": {
            "cotovelo": "EmRepouso",
            "pulso": "EmRepouso"
        }
    });
    const [cotovelos, setCotovelos] = useState([]);
    const [pulsos, setPulsos] = useState([]);
    const [inclinacoes, setInclinacoes] = useState([]);
    const [rotacoes, setRotacoes] = useState([]);
    const [showAlert, setShowAlert] = useState(false);
    const [alertMessage, setAlertMessage] = useState("");

    useEffect(async () => {
        setRobo(await getRobo());
        setCotovelos(await getCotovelos());
        setPulsos(await getPulsos());
        setInclinacoes(await getInclinaoes());
        setRotacoes(await getRotacoes());
    }, [])

    const getRobo = async () => {
        const response = await fetch('robo');
        return await response.json();
    }

    const getCotovelos = async () => {
        const response = await fetch('robo/cotovelo');
        return await response.json();
    }

    const getPulsos = async () => {
        const response = await fetch('robo/pulso');
        return await response.json();
    }

    const getInclinaoes = async () => {
        const response = await fetch('robo/inclinacao');
        return await response.json();
    }

    const getRotacoes = async () => {
        const response = await fetch('robo/rotacao');
        return await response.json();
    }
    
    const updateRobot = async (movimento, value) => {
        const settings = {
            method: 'PUT',
            headers: {
                Accept: 'application/json',
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({
                movimento: movimento,
                valor: value
            })
        };
        
        const response = await fetch('robo', settings);
        const data = await response.json();
        
        if (data.error) {
            setShowAlert(true);

            setAlertMessage(data.error);
        } else {
            setRobo(data); 
        }
    }

    return (
        <>
            {showAlert && (
                <div className="justify-content-center position-absolute w-75 l-50" style={{
                    zIndex:100,
                    left: "50%",
                    transform: "translate(-50%, -50%)"
                }}>
                    <Alert
                        color="danger"
                        toggle={() => setShowAlert(false)}
                    >
                        {alertMessage}
                    </Alert>
                </div>
            )}
            <Robot robo={robo} />
            <div className="mb-6">
                <div className="d-flex flex-row justify-content-around">
                    <Card 
                        title="Braço Esquerdo" 
                        subTitle1="Cotovelo" 
                        subTitle2="Pulso" 
                        list1={cotovelos} 
                        list2={pulsos} 
                        item1="CotoveloEsquerdo"
                        item2="PulsoEsquerdo"
                        value1={robo.bracoEsquerdo.cotovelo}
                        value2={robo.bracoEsquerdo.pulso}
                        updateRobot={updateRobot}
                    />
                    <Card
                        title="Cabeça"
                        subTitle1="Inclinação"
                        subTitle2="Rotação"
                        list1={inclinacoes}
                        list2={rotacoes}
                        item1="Inclinacao"
                        item2="Rotacao"
                        value1={robo.cabeca.inclinacao}
                        value2={robo.cabeca.rotacao}
                        updateRobot={updateRobot}
                    />
                    <Card
                        title="Braço Direito"
                        subTitle1="Cotovelo"
                        subTitle2="Pulso"
                        list1={cotovelos}
                        list2={pulsos}
                        item1="CotoveloDireito"
                        item2="PulsoDireito"
                        value1={robo.bracoDireito.cotovelo}
                        value2={robo.bracoDireito.pulso}
                        updateRobot={updateRobot}
                    />
                </div>
            </div>
        </>
    );
}