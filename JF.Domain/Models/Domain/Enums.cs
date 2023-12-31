﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JF.Domain.Models.Domain
{
    public enum Jobs
    {
        [Description("Администратор базы данных")]
        Администраторбазыданных = 1,
        [Description("Веб-интегратор")]
        Вебинтегратор,
        [Description("Веб-мастер")]
        Вебмастер,
        [Description("Монтажник связи")]
        Монтажниксвязи,
        [Description("Оператор ПК")]
        ОператорПК,
        [Description("Программист")]
        Программист,
        [Description("Кодер")]
        Кодер,
        [Description("Веб-программист")]
        Вебпрограммист,
        [Description("Радист")]
        Радист,
        [Description("Робототехник")]
        Робототехник,
        [Description("Системный администратор")]
        Системныйадминистратор,
        [Description("Телеграфист")]
        Телеграфист,
        [Description("Телефонист")]
        Телефонист,
        [Description("Тестировщик")]
        Тестировщик,
        [Description("Аудитор")]
        Аудитор,
        [Description("Актуарий")]
        Актуарий,
        [Description("Аналитик")]
        Аналитик,
        [Description("Банкир")]
        Банкир,
        [Description("Брокер")]
        Брокер,
        [Description("Бухгалтер")]
        Бухгалтер,
        [Description("Дилер")]
        Дилер,
        [Description("Продавец")]
        Продавец,
        [Description("Инкассатор")]
        Инкассатор,
        [Description("Коммерческий директор")]
        Коммерческийдиректор,
        [Description("Кредитный консультант")]
        Кредитныйконсультант,
        [Description("Маркетолог")]
        Маркетолог,
        [Description("Маклер биржевой")]
        Маклербиржевой,
        [Description("Менеджер по работе с клиентами")]
        Менеджерпоработесклиентами,
        [Description("Налоговый инспекстор")]
        Налоговыйинспектор,
        [Description("Операционист")]
        Операционист,
        [Description("Предприниматель")]
        Предприниматель,
        [Description("Сметчик")]
        Сметчик,
        [Description("Снабженец")]
        Снабженец,
        [Description("Страховой агент")]
        Страховойагент,
        [Description("Релайтер")]
        Релайтер,
        [Description("Товаровед")]
        Товаровед,
        [Description("Торговый представитель")]
        Торговыйпредставитель,
        [Description("Трендвотчер")]
        Трендвотчер,
        [Description("Трейдер")]
        Трейдер,
        [Description("Экономист")]
        Экономист,
        [Description("Экспедитор")]
        Экспедитор,
        [Description("Финансист")]
        Финансист,
        [Description("Кассир")]
        Кассир,
        [Description("Автослесарь")]
        Автослесарь,
        [Description("Автоэлектрик")]
        Автоэлектрик,
        [Description("Аккумуляторщик")]
        Аккумуляторщик,
        [Description("Бондарь")]
        Бондарь, 
        [Description("Бульдозерист")]
        Бульдозерист,
        [Description("Горняк")]
        Горняк,
        [Description("Грейдерист")]
        Грейдерист,
        [Description("Дизайнер-конструктор")]
        Дизайнерконструктор,
        [Description("Драпировщик")]
        Драпировщик,
        [Description("Заточник")]
        Заточник,
        [Description("Землекоп")]
        Землекоп,
        [Description("Инженер")]
        Инженер,
        [Description("Инженер-акустик")]
        Инженеракустик,
        [Description("Инженер-взрывотехник")]
        Инженервзрывотехник,
        [Description("Инженер-гальваник")]
        Инженергальваник,
        [Description("Инженер-гидравлик")]
        Инженергидравлик,
        [Description("Инженер КИПиА")]
        ИнженерКИПиА,
        [Description("Инженер-конструктор")]
        Инженерконструктор,
        [Description("Инженер-механик")]
        Инженермеханик,
        [Description("Инженер по Технике Безопасности")]
        ИнженерпоТехникеБезопасности,
        [Description("Инженер-системотехник")]
        Инженерсистемотехник,
        [Description("Инженер-строитель")]
        Инженерстроитель,
        [Description("Инженер-технолог")]
        Инженертехнолог,
        [Description("Инженер-физик")]
        Инженерфизик,
        [Description("Инженер-электрик")]
        Инженерэлектрик,
        [Description("Инженер-энергетик")]
        Инженерэнергетик,
        [Description("Кабельщик")]
        Кабельщик,
        [Description("Каменотес")]
        Каменотёс,
        [Description("Крановщик")]
        Крановщик,
        [Description("Кровельщик")]
        Кровельщик,
        [Description("Кромкозакатчик")]
        Кромкозакатчик,
        [Description("Кузнец")]
        Кузнец,
        [Description("Лекальщик")]
        Лекальщик,
        [Description("Литейщик")]
        Литейщик,
        [Description("Маляр")]
        Маляр,
        [Description("Маркшейдер")]
        Маркшейдер,
        [Description("Машинист")]
        Машинист,
        [Description("Медник")]
        Медник,
        [Description("Металлург")]
        Металлург,
        [Description("Механик")]
        Механик,
        [Description("Монтажник")]
        Монтажник,
        [Description("Моторист")]
        Моторист,
        [Description("Печник")]
        Печник,
        [Description("Плиточник")]
        Плиточник,
        [Description("Плотник")]
        Плотник,
        [Description("Промышленный альпинист")]
        Промышленныйальпинист,
        [Description("Проходчик")]
        Проходчик, 
        [Description("Радиомеханик")]
        Радиомеханик,
        [Description("Распиловщик")]
        Распиловщик,
        [Description("Расточник")]
        Расточник,
        [Description("Рихтовщик")]
        Рихтовщик,
        [Description("Сантехник")]
        Сантехник,
        [Description("Сборщик")]
        Сборщик,
        [Description("Сварщик")]
        Сварщик,
        [Description("Слесарь")]
        Слесарь,
        [Description("Скорняк")]
        Скорняк,
        [Description("Сталевар")]
        Сталевар,
        [Description("Столяр")]
        Столяр,
        [Description("Столяр-краснодеревщик")]
        Столяркраснодеревщик,
        [Description("Строитель")]
        Строитель,
        [Description("Техник")]
        Техник,
        [Description("Технолог")]
        Технолог,
        [Description("Токарь")]
        Токарь,
        [Description("Токарь-карусельщик")]
        Токарькарусельщик,
        [Description("Формовщик")]
        Формовщик,
        [Description("Фрезеровщик")]
        Фрезеровщик, 
        [Description("Холодильщик")]
        Холодильщик,
        [Description("Шахтер")]
        Шахтёр,
        [Description("Швея")]
        Швея,
        [Description("Шлифовщик")]
        Шлифовщик,
        [Description("Шорник")]
        Шорник,
        [Description("Штукатур")]
        Штукатур,
        [Description("Электрик")]
        Электрик,
        [Description("Воспитатель")]
        Воспитатель,
        [Description("Декан")]
        Декан,
        [Description("Дефектолог")]
        Дефектолог,
        [Description("Логопед")]
        Логопед,
        [Description("Педагог")]
        Педагог,
        [Description("Преподаватель")]
        Преподаватель,
        [Description("Проректор")]
        Проректор,
        [Description("Психолог")]
        Психолог,
        [Description("Ректор")]
        Ректор,
        [Description("Сурдопедагог")]
        Сурдопедагог,
        [Description("Тифлопедагог")]
        Тифлопедагог,
        [Description("Учитель")]
        Учитель, 
        [Description("Агроном")]
        Агроном,
        [Description("Бахчевод")]
        Бахчевод,
        [Description("Агроном-почвовед")]
        Агрономпочвовед,
        [Description("Агроном по защите растений")]
        Агрономпозащитерастений,
        [Description("Ветеринар")]
        Ветеринар,
        [Description("Виноградарь")]
        Виноградарь,
        [Description("Доярка")]
        Доярка,
        [Description("Животновод")]
        Животновод,
        [Description("Жиловщик / Обвальщик")]
        ЖиловщикОбвальщик,
        [Description("Зоотехник")]
        Зоотехник,
        [Description("Коневод")]
        Коневод,
        [Description("Комбайнер")]
        Комбайнер,
        [Description("Инженер-лесотехник")]
        Инженерлесотехник,
        [Description("Инженер по механизации")]
        Инженерпомеханизации,
        [Description("Механизатор")]
        Механизатор,
        [Description("Мелиоратор")]
        Мелиоратор,
        [Description("Мясник")]
        Мясник,
        [Description("Оператор машинного доения")]
        Оператормашинногодоения,
        [Description("Овчар")]
        Овчар,
        [Description("Пастух")]
        Пастух,
        [Description("Растениевод")]
        Растениевод,
        [Description("Садовод")]
        Садовод,
        [Description("Свинопас")]
        Свинопас,
        [Description("Скотник")]
        Скотник,
        [Description("Специалист по стрижке овец")]
        Специалистпострижкеовец,
        [Description("Табаковод")]
        Табаковод,
        [Description("Табунщик")]
        Табунщик,
        [Description("Тракторист")]
        Тракторист,
        [Description("Пчеловод")]
        Пчеловод,
        [Description("Фермер")]
        Фермер,
        [Description("Хлебороб")]
        Хлебороб,
        [Description("Хлопокороб")]
        Хлопокороб,

    }

    public enum Otrasli
    {
        [Description("Административный персонал")]
        Административныйперсонал = 1,
        [Description("Дизайн / Полиграфия / СМИ")]
        ДизайнПолиграфияСМИ,
        [Description("Закупки / Снабжение")]
        ЗакупкиСнабжение,
        [Description("Информационные технологии / IT")]
        ИнформационныетехнологииIT,
        [Description("Искусство / Культура / Развлечения")]
        ИскусствоКультураРазвлечения,
        [Description("Кадровая служба / Тренинги / HR")]
        КадроваяслужбаТренингиHR,
        [Description("Маркетинг / Реклама / PR")]
        МаркетингРекламаPR,
        [Description("Медицина / Фармацевтика")]
        МедицинаФармацевтика,
        [Description("Образование / Воспитание / Наука")]
        ОбразованиеВоспитаниеНаука,
        [Description("Охрана / Безопасность")]
        ОхранаБезопасность,
        [Description("Персонал для дома")]
        Персоналдлядома,
        [Description("Производство / Промышленность")]
        ПроизводствоПромышленность,
        [Description("Работа для молодежи")]
        Работадлямолодежи,
        [Description("Рабочие специальности")]
        Рабочиеспециальности,
        [Description("Склад / Логистика / ВЭД")]
        СкладЛогистикаВЭД,
        [Description("Спорт / Красота")]
        СпортКрасота,
        [Description("Страхование")]
        Страхование,
        [Description("Строительство / Недвижимость")]
        СтроительствоНедвижимость,
        [Description("Торговля / Продажи")]
        ТорговляПродажи,
        [Description("Транспорт / Автобизнес")]
        ТранспортАвтобизнес,
        [Description("Туризм / Рестораны / Гостиницы")]
        ТуризмРестораныГостиницы,
        [Description("Финансы / Бухгалтерия / Банки")]
        ФинансыБухгалтерияБанки,
        [Description("Юриспруденция")]
        Юриспруденция,

    }

    public enum Graphs
    {
        [Description("Полный день")]
        Полныйдень = 1,
        [Description("Сменный график")]
        Сменный,
        [Description("Гибкий график")]
        Гибкий,
        [Description("Подработка")]
        Подработка,
        [Description("Удаленная работа")]
        Удаленнаяработа,
        [Description("Вахта")]
        Вахта
    }

    public enum UserEducation
    {
        BasicGeneral = 1,
        GeneralSecondary,
        SecondaryProfessional,
        Higher
    }
    public enum UserRole
    {
        Worker = 1,
        Hirer
    }
    public enum Status
    {
        Inprocess = 1,
        Done
    }
}
