import { AnimationType } from './animation';
import { AxisType } from './axis';
import { CounterType } from './counter';
import { DirectionType } from './direction';
import { DragHandlerType } from './dragHandler';
import { EventEmitterType } from './eventEmitter';
import { LimitType } from './limit';
import { OptionsType } from './options';
import { PxToPercentType } from './pxToPercent';
import { ScrollBodyType } from './scrollBody';
import { ScrollBoundsType } from './scrollBounds';
import { ScrollLooperType } from './scrollLooper';
import { ScrollProgressType } from './scrollProgress';
import { ScrollTargetType } from './scrollTarget';
import { ScrollToType } from './scrollTo';
import { SlideLooperType } from './slideLooper';
import { SlideFocusType } from './slideFocus';
import { SlidesInViewType } from './slidesInView';
import { TranslateType } from './translate';
import { Vector1DType } from './vector1d';
export declare type Engine = {
    axis: AxisType;
    direction: DirectionType;
    animation: AnimationType;
    scrollBounds: ScrollBoundsType;
    scrollLooper: ScrollLooperType;
    scrollProgress: ScrollProgressType;
    index: CounterType;
    indexPrevious: CounterType;
    limit: LimitType;
    location: Vector1DType;
    options: OptionsType;
    pxToPercent: PxToPercentType;
    scrollBody: ScrollBodyType;
    dragHandler: DragHandlerType;
    slideFocus: SlideFocusType;
    slideLooper: SlideLooperType;
    slidesInView: SlidesInViewType;
    target: Vector1DType;
    translate: TranslateType;
    scrollTo: ScrollToType;
    scrollTarget: ScrollTargetType;
    scrollSnaps: number[];
    slideIndexes: number[];
};
export declare function Engine(root: HTMLElement, container: HTMLElement, slides: HTMLElement[], options: OptionsType, events: EventEmitterType): Engine;
