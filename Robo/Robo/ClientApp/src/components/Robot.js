import React from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import './Home.css';

export function Robot({ robo }) {
    const renderRotacao = () => {
        switch (robo.cabeca.rotacao) {
            case "RotacaoMenos45":
                return `rotate(-45deg)`;
            case "RotacaoMenos90":
                return `rotate(-90deg)`;
            case "EmRepouso":
                return "";
            case "Rotacao45":
                return `rotate(45deg)`;
            case "Rotacao90":
                return `rotate(90deg)`;
        }
    }

    const renderInclinacao = () => {
        switch (robo.cabeca.inclinacao) {
            case "ParaCima":
                return "-10px";
            case "EmRepouso":
                return "";
            case "ParaBaixo":
                return "10px";
        }
    }

    const renderCotovelo = (cotovelo) => {
        switch (cotovelo) {
            case "EmRepouso":
                return "";
            case "LevementeContraido":
                return `rotate(45deg)`;
            case "Contraido":
                return `rotate(60deg)`;
            case "FortementeContraido":
                return `rotate(85deg)`;
        }
    }

    const renderHandPosition = (cotovelo) => {
        switch (cotovelo) {
            case "EmRepouso":
                return "";
            case "LevementeContraido":
            case "Contraido":
            case "FortementeContraido":
                return "relative";
        }
    }

    const renderHandLeft = (cotovelo, esquerda) => {
        switch (cotovelo) {
            case "EmRepouso":
                return "";
            case "LevementeContraido":
                return (esquerda ? "" : "-") + "25px";
            case "Contraido":
                return (esquerda ? "" : "-") + "30px";
            case "FortementeContraido":
                return (esquerda ? "" : "-") + "34px";
        }
    }

    const renderHandTop = (cotovelo, esquerda) => {
        switch (cotovelo) {
            case "EmRepouso":
                return "";
            case "LevementeContraido":
                return "-15px";
            case "Contraido":
                return "-18px";
            case "FortementeContraido":
                return "-25px";
        }
    }

    const renderPulso = (pulso) => {
        switch (pulso){
            case "RotacaoMenos45":
                return `rotate(-45deg)`;
            case "RotacaoMenos90":
                return `rotate(-90deg)`;
            case "EmRepouso":
                return "";
            case "Rotacao45":
                return `rotate(45deg)`;
            case "Rotacao90":
                return `rotate(90deg)`;
            case "Rotacao135":
                return `rotate(135deg)`;
            case "Rotacao180":
                return `rotate(180deg)`;
        }
    }

    return (
        <div className="robot">
            <div className="head" style={{ 
                transform: renderRotacao(),
                top: renderInclinacao()
            }}>
                <div className="eye left-eye"></div>
                <div className="antenna"></div>
                <div className="eye right-eye"></div>
            </div>
            <div className="neck"></div>
            <div className="body">
                <div className="full-arm">
                    <div className="sholder"></div>
                    <div className="elbow"></div>
                    <div className="arm" style={{
                         transform: renderCotovelo(robo.bracoEsquerdo.cotovelo, true)
                     }}></div>
                    <div className="hand" style={{
                        position: renderHandPosition(robo.bracoEsquerdo.cotovelo),
                        left: renderHandLeft(robo.bracoEsquerdo.cotovelo, true),
                        top: renderHandTop(robo.bracoEsquerdo.cotovelo, true),
                        transform: renderPulso(robo.bracoEsquerdo.pulso)
                    }}></div>
                </div>
                <div className="torso"></div>
                <div className="full-arm">
                    <div className="sholder"></div>
                    <div className="elbow"></div>
                    <div className="arm" style={{
                        transform: renderCotovelo(robo.bracoDireito.cotovelo, false)
                    }}></div>
                    <div className="hand" style={{
                        position: renderHandPosition(robo.bracoDireito.cotovelo),
                        left: renderHandLeft(robo.bracoDireito.cotovelo, false),
                        top: renderHandTop(robo.bracoDireito.cotovelo, false),
                        transform: renderPulso(robo.bracoDireito.pulso)
                    }}></div>
                </div>
            </div>
        </div>
    );
}