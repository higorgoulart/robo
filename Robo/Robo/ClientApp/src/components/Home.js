import React, {useEffect, useState} from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import './Home.css';
import {Alert} from "reactstrap";
import {Robot} from "./Robot";

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
    const [show, setShow] = useState(false);
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
            setShow(true);

            setAlertMessage(data.error);
        } else {
            setRobo(data); 
        }
    }

    return (
        <>
            {show && (
                <div className="justify-content-center position-absolute w-75 l-50" style={{
                    zIndex:100,
                    left: "50%",
                    transform: "translate(-50%, -50%)"
                }}>
                    <Alert
                        color="danger"
                        toggle={() => setShow(false)}
                    >
                        {alertMessage}
                    </Alert>
                </div>
            )}
            <Robot robo={robo} />
            <div className="mb-6">
                <div className="d-flex flex-row justify-content-around">
                    <div>
                        <h1>Braço Esquerdo</h1>
                        <div className="d-flex flex-column">
                            <b>Cotovelo: {robo.bracoEsquerdo.cotovelo}</b>
                            <select onChange={(e) => updateRobot("CotoveloEsquerdo", e.target.value)} className="form-select">
                                {cotovelos.map(cotovelo => {
                                    return <option key={cotovelo.key} value={cotovelo.key} selected={cotovelo.key === robo.bracoEsquerdo.cotovelo}>{cotovelo.value}</option>
                                })}
                            </select>
                            <b>Pulso: {robo.bracoEsquerdo.pulso}</b>
                            <select onChange={(e) => updateRobot("PulsoEsquerdo", e.target.value)} className="form-select">
                                {pulsos.map(pulso => {
                                    return <option key={pulso.key} value={pulso.key} selected={pulso.key === robo.bracoEsquerdo.pulso}>{pulso.value}</option>
                                })}
                            </select>
                        </div>
                    </div>
                    <div>
                        <h1>Cabeça</h1>
                        <div className="d-flex flex-column">
                            <b>Inclinação: {robo.cabeca.inclinacao}</b>
                            <select onChange={(e) => updateRobot("Inclinacao", e.target.value)} className="form-select">
                                {inclinacoes.map(inclinacao => {
                                    return <option key={inclinacao.key} value={inclinacao.key} selected={inclinacao.key === robo.cabeca.inclinacao}>{inclinacao.value}</option>
                                })}
                            </select>
                            <b>Rotação: {robo.cabeca.rotacao}</b>
                            <select onChange={(e) => updateRobot("Rotacao", e.target.value)} className="form-select">
                                {rotacoes.map(rotacao => {
                                    return <option key={rotacao.key} value={rotacao.key} selected={rotacao.key === robo.cabeca.rotacao}>{rotacao.value}</option>
                                })}
                            </select>
                        </div>
                    </div>
                    <div>
                        <h1>Braço Direito</h1>
                        <div className="d-flex flex-column">
                            <b>Cotovelo: {robo.bracoDireito.cotovelo}</b>
                            <select onChange={(e) => updateRobot("CotoveloDireito", e.target.value)} className="form-select">
                                {cotovelos.map(cotovelo => {
                                    return <option key={cotovelo.key} value={cotovelo.key} selected={cotovelo.key === robo.bracoDireito.cotovelo}>{cotovelo.value}</option>
                                })}
                            </select>
                            <b>Pulso: {robo.bracoDireito.pulso}</b>
                            <select onChange={(e) => updateRobot("PulsoDireito", e.target.value)} className="form-select">
                                {pulsos.map(pulso => {
                                    return <option key={pulso.key} value={pulso.key} selected={pulso.key === robo.bracoDireito.pulso}>{pulso.value}</option>
                                })}
                            </select>
                        </div>
                    </div>
                </div>
            </div>
        </>
    );
}