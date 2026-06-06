```sql
-- ============================================================
-- GESTAO OS
-- SISTEMA DE GESTÃO DE ORDENS DE SERVIÇO
-- ============================================================
--
-- Autor:
-- Armando de Souza Reche Modenês
--
-- Banco:
-- PostgreSQL
--
-- Schema:
-- gestao
--
-- ============================================================
-- DESCRIÇÃO
-- ============================================================
--
-- Este script cria a estrutura completa do banco de dados
-- utilizado pelo sistema Gestão OS.
--
-- O script contempla:
--
-- 1. Criação do banco de dados gestao_os
-- 2. Criação do schema gestao
-- 3. Criação das tabelas principais
-- 4. Primary Keys
-- 5. Foreign Keys
-- 6. Constraints de integridade
-- 7. Índices para otimização de consultas
-- 8. Índice parcial para OS abertas
-- 9. Tabela de auditoria
-- 10. Function e triggers de auditoria
-- 11. Function e trigger para recálculo automático do total da OS
--
-- ============================================================
-- COMO EXECUTAR
-- ============================================================
--
-- OPÇÃO 1 - PGADMIN
--
-- 1. Abra o pgAdmin.
-- 2. Conecte no servidor PostgreSQL.
-- 3. Execute primeiro apenas o bloco CREATE DATABASE.
-- 4. Conecte no banco gestao_os.
-- 5. Execute o restante do script a partir de:
--
--      CREATE SCHEMA IF NOT EXISTS gestao;
--
--
-- OPÇÃO 2 - TERMINAL PSQL
--
-- Execute:
--
--      psql -U postgres -f 01_CREATE_DATABASE.sql
--
--
-- OBSERVAÇÃO
--
-- Dependendo da ferramenta utilizada, o comando CREATE DATABASE
-- pode precisar ser executado separadamente dos demais comandos.
--
-- ============================================================


-- ============================================================
-- CRIAÇÃO DO BANCO DE DADOS
-- ============================================================

CREATE DATABASE gestao_os
WITH
OWNER = postgres
ENCODING = 'UTF8'
TEMPLATE = template0;


-- ============================================================
-- SCHEMA
-- ============================================================
-- Após criar o banco, conecte-se ao banco gestao_os
-- antes de executar os comandos abaixo.
-- ============================================================

CREATE SCHEMA IF NOT EXISTS gestao;

SET search_path TO gestao;


-- ============================================================
-- CLIENTE
-- ============================================================

CREATE TABLE cliente (
    cliente_id          SERIAL PRIMARY KEY,
    nome                VARCHAR(150) NOT NULL,
    documento           VARCHAR(14) NOT NULL,
    tipo_pessoa         SMALLINT NOT NULL,
    email               VARCHAR(150) NOT NULL,
    telefone            VARCHAR(20) NOT NULL,
    data_cadastro       TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    ativo               BOOLEAN NOT NULL DEFAULT TRUE,

    CONSTRAINT uq_cliente_documento
        UNIQUE(documento),

    CONSTRAINT ck_cliente_nome
        CHECK(length(trim(nome)) >= 3),

    CONSTRAINT ck_cliente_tipo
        CHECK(tipo_pessoa IN (1,2))
);

CREATE INDEX ix_cliente_documento
ON cliente(documento);

CREATE INDEX ix_cliente_ativo
ON cliente(ativo);

CREATE INDEX ix_cliente_nome_ativo
ON cliente(nome, ativo);


-- ============================================================
-- SERVICO
-- ============================================================

CREATE TABLE servico (
    servico_id              SERIAL PRIMARY KEY,
    nome                    VARCHAR(150) NOT NULL,
    valor_base              NUMERIC(18,2) NOT NULL,
    percentual_imposto      NUMERIC(5,2) NOT NULL,
    ativo                   BOOLEAN NOT NULL DEFAULT TRUE,

    CONSTRAINT ck_servico_nome
        CHECK(length(trim(nome)) >= 3),

    CONSTRAINT ck_servico_valor
        CHECK(valor_base > 0),

    CONSTRAINT ck_servico_imposto
        CHECK(percentual_imposto >= 0
          AND percentual_imposto <= 100)
);

CREATE INDEX ix_servico_ativo
ON servico(ativo);


-- ============================================================
-- ORDEM DE SERVIÇO
-- ============================================================

CREATE TABLE ordem_servico (
    ordem_servico_id    SERIAL PRIMARY KEY,
    cliente_id          INT NOT NULL,
    data_abertura       TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    data_conclusao      TIMESTAMP NULL,
    status              SMALLINT NOT NULL,
    observacao          TEXT NULL,
    valor_total         NUMERIC(18,2) NOT NULL DEFAULT 0,
    versao              INTEGER NOT NULL DEFAULT 1,

    CONSTRAINT fk_os_cliente
        FOREIGN KEY(cliente_id)
        REFERENCES cliente(cliente_id)
        ON DELETE RESTRICT,

    CONSTRAINT ck_os_status
        CHECK(status IN (1,2,3,4)),

    CONSTRAINT ck_os_valor_total
        CHECK(valor_total >= 0)
);

CREATE INDEX ix_os_data_abertura
ON ordem_servico(data_abertura);

CREATE INDEX ix_os_status
ON ordem_servico(status);

CREATE INDEX ix_os_cliente
ON ordem_servico(cliente_id);

-- Índice parcial para otimizar consultas de OS abertas por cliente.
CREATE INDEX ix_os_aberta
ON ordem_servico(cliente_id)
WHERE status = 1;


-- ============================================================
-- ITEM DA ORDEM DE SERVIÇO
-- ============================================================

CREATE TABLE ordem_servico_item (
    ordem_servico_item_id          SERIAL PRIMARY KEY,
    ordem_servico_id               INT NOT NULL,
    servico_id                     INT NOT NULL,
    quantidade                     NUMERIC(18,2) NOT NULL,
    valor_unitario                 NUMERIC(18,2) NOT NULL,
    percentual_imposto_aplicado    NUMERIC(5,2) NOT NULL,
    valor_total_item               NUMERIC(18,2) NOT NULL,

    CONSTRAINT fk_item_os
        FOREIGN KEY(ordem_servico_id)
        REFERENCES ordem_servico(ordem_servico_id)
        ON DELETE CASCADE,

    CONSTRAINT fk_item_servico
        FOREIGN KEY(servico_id)
        REFERENCES servico(servico_id)
        ON DELETE RESTRICT,

    CONSTRAINT ck_item_qtd
        CHECK(quantidade > 0),

    CONSTRAINT ck_item_valor
        CHECK(valor_unitario >= 0),

    CONSTRAINT ck_item_imposto
        CHECK(
            percentual_imposto_aplicado >= 0
            AND percentual_imposto_aplicado <= 100
        ),

    CONSTRAINT ck_item_total
        CHECK(valor_total_item >= 0)
);

CREATE INDEX ix_item_os
ON ordem_servico_item(ordem_servico_id);


-- ============================================================
-- HISTÓRICO DE STATUS
-- ============================================================

CREATE TABLE historico_status (
    historico_status_id     SERIAL PRIMARY KEY,
    ordem_servico_id        INT NOT NULL,
    status_anterior         SMALLINT NULL,
    status_novo             SMALLINT NOT NULL,
    data_hora               TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    usuario                 VARCHAR(100) NULL,

    CONSTRAINT fk_hist_os
        FOREIGN KEY(ordem_servico_id)
        REFERENCES ordem_servico(ordem_servico_id)
        ON DELETE CASCADE
);

CREATE INDEX ix_hist_os
ON historico_status(ordem_servico_id);


-- ============================================================
-- AUDITORIA
-- ============================================================

CREATE TABLE auditoria (
    auditoria_id        BIGSERIAL PRIMARY KEY,
    entidade            VARCHAR(100) NOT NULL,
    id_registro         BIGINT NOT NULL,
    operacao            VARCHAR(10) NOT NULL,
    data_hora           TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    usuario             VARCHAR(100),
    snapshot_json       JSONB NOT NULL
);

CREATE INDEX ix_auditoria_entidade
ON auditoria(entidade);

CREATE INDEX ix_auditoria_data
ON auditoria(data_hora);


-- ============================================================
-- FUNCTION DE AUDITORIA
-- ============================================================

CREATE OR REPLACE FUNCTION gestao.fn_auditoria()
RETURNS trigger
LANGUAGE plpgsql
AS
$$
DECLARE
    v_snapshot JSONB;
    v_id_registro BIGINT;
BEGIN
    IF TG_OP = 'DELETE' THEN
        v_snapshot := to_jsonb(OLD);
    ELSE
        v_snapshot := to_jsonb(NEW);
    END IF;

    v_id_registro := COALESCE(
        NULLIF(v_snapshot ->> 'ordem_servico_id', '')::BIGINT,
        NULLIF(v_snapshot ->> 'ordem_servico_item_id', '')::BIGINT,
        NULLIF(v_snapshot ->> 'historico_status_id', '')::BIGINT,
        0
    );

    INSERT INTO gestao.auditoria (
        entidade,
        id_registro,
        operacao,
        data_hora,
        usuario,
        snapshot_json
    )
    VALUES (
        TG_TABLE_NAME,
        v_id_registro,
        TG_OP,
        CURRENT_TIMESTAMP,
        CURRENT_USER,
        v_snapshot
    );

    IF TG_OP = 'DELETE' THEN
        RETURN OLD;
    END IF;

    RETURN NEW;
END;
$$;


-- ============================================================
-- TRIGGERS DE AUDITORIA
-- ============================================================

DROP TRIGGER IF EXISTS trg_auditoria_os
ON gestao.ordem_servico;

CREATE TRIGGER trg_auditoria_os
AFTER INSERT OR UPDATE OR DELETE
ON gestao.ordem_servico
FOR EACH ROW
EXECUTE FUNCTION gestao.fn_auditoria();


DROP TRIGGER IF EXISTS trg_auditoria_item
ON gestao.ordem_servico_item;

CREATE TRIGGER trg_auditoria_item
AFTER INSERT OR UPDATE OR DELETE
ON gestao.ordem_servico_item
FOR EACH ROW
EXECUTE FUNCTION gestao.fn_auditoria();


DROP TRIGGER IF EXISTS trg_auditoria_historico_status
ON gestao.historico_status;

CREATE TRIGGER trg_auditoria_historico_status
AFTER INSERT OR UPDATE OR DELETE
ON gestao.historico_status
FOR EACH ROW
EXECUTE FUNCTION gestao.fn_auditoria();


-- ============================================================
-- FUNCTION DE RECÁLCULO DO TOTAL DA OS
-- ============================================================

CREATE OR REPLACE FUNCTION gestao.fn_recalcular_total_os()
RETURNS trigger
LANGUAGE plpgsql
AS
$$
DECLARE
    v_ordem_servico_id INT;
BEGIN
    IF TG_OP = 'DELETE' THEN
        v_ordem_servico_id := OLD.ordem_servico_id;
    ELSE
        v_ordem_servico_id := NEW.ordem_servico_id;
    END IF;

    UPDATE gestao.ordem_servico
    SET valor_total =
        COALESCE(
            (
                SELECT SUM(valor_total_item)
                FROM gestao.ordem_servico_item
                WHERE ordem_servico_id = v_ordem_servico_id
            ),
            0
        )
    WHERE ordem_servico_id = v_ordem_servico_id;

    RETURN NULL;
END;
$$;


-- ============================================================
-- TRIGGER DE RECÁLCULO DO TOTAL DA OS
-- ============================================================

DROP TRIGGER IF EXISTS trg_recalcular_total_os
ON gestao.ordem_servico_item;

CREATE TRIGGER trg_recalcular_total_os
AFTER INSERT OR UPDATE OR DELETE
ON gestao.ordem_servico_item
FOR EACH ROW
EXECUTE FUNCTION gestao.fn_recalcular_total_os();


-- ============================================================
-- FIM DO SCRIPT
-- ============================================================
--
-- Estrutura criada:
--
-- ✓ Banco de dados
-- ✓ Schema gestao
-- ✓ Tabelas principais
-- ✓ Primary Keys
-- ✓ Foreign Keys
-- ✓ Constraints
-- ✓ Unique Constraint
-- ✓ Índices
-- ✓ Índice parcial
-- ✓ Auditoria via Function e Trigger
-- ✓ Histórico de status
-- ✓ Recálculo automático do valor total da OS
--
-- ============================================================
```
