import { useEffect, useState } from "react";
import { Span } from "../../atoms";
import "./index.css";

const TestUseEffect: React.FC = () => {
  const [victim, setVictim] = useState<unknown>({ p1: 0, p2: 0 });
  const [victimByVictim, setVictimByVictim] = useState<string>();
  const [victimByP1, setVictimByP1] = useState<string>();
  const [victimByP2, setVictimByP2] = useState<string>();

  useEffect(() => {
    setVictimByVictim(
      victim
        ? `useEffect([victim]): {p1: ${(victim as { [key: string]: any })["p1"]}, p2: ${(victim as { [key: string]: any })["p2"]}}`
        : undefined
    );
  }, [victim]);

  useEffect(() => {
    setVictimByP1(
      victim
        ? `useEffect([(victim as { [key: string]: any })["p1"]]): {p1: ${(victim as { [key: string]: any })["p1"]}, p2: ${(victim as { [key: string]: any })["p2"]}}`
        : undefined
    );
  }, [(victim as { [key: string]: any })["p1"]]);

  useEffect(() => {
    setVictimByP2(
      victim
        ? `useEffect([(victim as { [key: string]: any })["p2"]]): {p1: ${(victim as { [key: string]: any })["p1"]}, p2: ${(victim as { [key: string]: any })["p2"]}}`
        : undefined
    );
  }, [(victim as { [key: string]: any })["p2"]]);

  return (
    <div>
      <h1>useEffect</h1>
      <div>
        <p>
          <Span text="Span# 1" />
          <Span text="Span# 1" />
          <Span text="Span# 2" />
        </p>
        {!!victimByVictim ? <p>{victimByVictim}</p> : undefined}
        {!!victimByP1 ? <p>{victimByP1}</p> : undefined}
        {!!victimByP2 ? <p>{victimByP2}</p> : undefined}
      </div>
      <div>
        <input
          type="button"
          value="victim"
          onClick={() => setVictim({ p1: 0, p2: 0 })}
        />
        <input
          type="button"
          value="victim.p1"
          onClick={() => setVictim((v: any) => ({ ...v, p1: (v as { [key: string]: any })["p1"] + 1 }))}
        />
        <input
          type="button"
          value="victim.p2"
          onClick={() => setVictim((v: any) => ({ ...v, p2: (v as { [key: string]: any })["p2"] + 1 }))}
        />
      </div>
    </div>
  );
};

export default TestUseEffect;
